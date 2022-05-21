using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using ProjectMVC.Features.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Infrastructure;
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
            Console.WriteLine("tu login username " + model.userName + " password " + model.password);



            // todo if len(select * from db where username = username && password == password) == 0
            if (model.userName == "error")
            {

                ViewData["error"] = true;
                return View("./index");

            }
            else {


                model.sessionId = GetUniqueKey(20);
                Console.WriteLine("session id", model.sessionId);

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
