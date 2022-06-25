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

using PetCareAppMVC.Features.Listings;


using PetCareAppMVC.Features;
using System.Security.Cryptography;
using System.Text;
using PetCareAppMVC.Features.Login;

namespace PetCareAppMVC.Features.Logout
{
    public class LogoutController : Controller
    {

        [HttpGet]
        public IActionResult Index(string sessionId, string UserName)
        {

            Console.WriteLine("logout index", sessionId);
            //Console.WriteLine(person);

            //person.SessionId = "";

            LoginViewModel person = new LoginViewModel();
            person.SessionId =  "";
            person.UserName = UserName;

            mapper.Map<UpdatePersonCommand>(person);


            //var retModel = new SessionViewModel();
            //retModel.sessionId = "empty";

            ////return RedirectToAction("Index", "Listings", retModel);

            //return RedirectToAction("Index", "Home", retModel);

            return View();
        }

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public LogoutController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

     


    }

}
