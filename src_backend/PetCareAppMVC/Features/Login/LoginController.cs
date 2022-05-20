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

        public LoginController (IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        
        [HttpPost]
        public async Task<ActionResult> LoginCheck(LoginViewModel model)
        {
            Console.WriteLine("tu login username " + model.userName + " password " + model.password);
            Console.WriteLine("tu login username " + model.userName+ " password " + model.password);

            Console.WriteLine(model.userName == "error");
            Console.WriteLine("ffffffffffffffffff");

            ViewData["error"] = "nema  errora vieew data";
            ViewBag.tmp = "view beg";
            TempData["tmp"] = "temp data";
            return RedirectToAction("");

            return View("Login");

            return View();

            if (model.userName == "error")
            {
                Console.WriteLine(model.userName == "error");
                ViewBag.errorMessage = "You must have a confirmed email to log on.";
                //return View("Login");

                return View();

            } else {
                Console.WriteLine(model.userName == "error");
                //return View("Login");

            }
            return RedirectToAction("/home");

            //return View("Login");

            //Create session id
            //return session id
            //log session in db 
            //session = session id + last req time


        }

    }

}
