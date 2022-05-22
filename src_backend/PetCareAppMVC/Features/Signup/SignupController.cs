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
using System.Security.Cryptography;
using System.Text;

namespace PetCareAppMVC.Features.Signup
{
    public class SignupController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public SignupController(IMapper mapper, IMediator mediator)
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
        public async Task<ActionResult> SignupCheck(SignupViewModel model)
        {
           
                var query = new DomainServices.People.Queries.GetPeopleQuery();
                var data = await mediator.Send(query);
                foreach (var item in data)
                {
                  //if (!item.UserName.Equals(model.UserName))
                  
                //{
                    var command = mapper.Map<AddPersonCommand>(model);
                    int id = await mediator.Send(command);

                    //}
                //}

                Console.WriteLine("model je validan");
            }

            ViewData["error"] = true;
            return View("./index");

            /*


            return View("../Listings/index", model);


            var query = new DomainServices.People.Queries.GetPeopleQuery();
            var data = await mediator.Send(query);
            var idP = data.Count() + 1;
            model.PersonId = idP;
            model.SessionId = model.SessionId + "ha";


            if (ModelState.IsValid)
            {

                var command = mapper.Map<AddPersonCommand>(model);
                int id = await mediator.Send(command);
                TempData.Put(Constants.ActionStatus, new ActionStatus(true, $"{model.UserName} {model.PersonEmail} added"));
            }

            Console.WriteLine("signup params" +model.UserName+model.Password);

            // if all ok redirect to login

            // if err return

            return RedirectToAction("");

            */
        }


    }


}
