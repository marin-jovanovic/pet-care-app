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

        public LoginController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> LoginCheck(string username, string password)
        {
            Console.WriteLine("login username " + username + " password " + password);

            //Create session id
            //return session id
            //log session in db 
            //session = session id + last req time


            return RedirectToAction(nameof(Index));
        }

    }

}
