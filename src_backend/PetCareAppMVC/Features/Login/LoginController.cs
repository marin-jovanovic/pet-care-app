using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using ProjectMVC.Features.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Infrastructure5;
using Sieve.Models;

//using Domain.Roles;
//using DomainServices.Roles;
using static DomainServices.People.Commands;
//using static DomainServices.People.Commands;

using PetCareAppMVC.Features;
using System.Security.Cryptography;
using System.Text;

namespace PetCareAppMVC.Features.Login
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public LoginController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        internal static readonly char[] chars =
                 "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GetUniqueKey(int size)
        {
            byte[] data = new byte[4 * size];
            using (var crypto = RandomNumberGenerator.Create())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }

        [HttpPost]

        public async Task<ActionResult> LoginCheck(LoginViewModel model)
        {
            Console.WriteLine("tu login username " + model.UserName + " password " + model.Password);

            
                Console.WriteLine("login check: model is valid");
                var query = new DomainServices.People.Queries.GetPeopleQuery();
                var data = await mediator.Send(query);
                foreach (var item in data)
                {
                    if(item.UserName.Equals( model.UserName) && item.Password.Equals(model.Password))
                    {
                    model.UserName = item.UserName;
                    model.PersonLastName = item.PersonLastName; 
                    model.PersonFirstName = item.PersonFirstName;   
                    model.Oib=item.Oib;
                    model.PersonMobile = model.PersonMobile;
                    model.Password = item.Password; 
                    model.PersonEmail= item.PersonEmail;    
                    model.PersonId=item.PersonId;   
                    model.SessionId = GetUniqueKey(20);
                    mapper.Map<UpdatePersonCommand>(model);

                    var query1 = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
                    //Console.WriteLine("session id", model.sessionId);
                    return View("../listings/index", query1);
                    }
                }

            

            ViewData["error"] = true;
            return View("./index");

            // todo if len(select * from db where username = username && password == password) == 0
            if (model.UserName == "error")
            {

                ViewData["error"] = true;
                return View("./index");

            }
            else {


                return View("../Listings/index", model);

            }

            //return View("Login");

            //Create session id
            //return session id
            //log session in db 
            //session = session id + last req time


        }

    }

}
