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

    

        [HttpPost]
        public async Task<ActionResult> SignupCheck(string username, string oib, string firstname, string lastname, string email, string cardnumber, string cardtype, string cardmonth, string cardyear, string password, string passwordrepeat)
        {
            Console.WriteLine("signup params" +" "+ username + " " + oib + " " + firstname + " " + lastname + " " + email + " " + cardnumber + " " + cardtype + " " + cardmonth + " " + cardyear + " " + password + " " + passwordrepeat);

            // if all ok redirect to login

            // if err return

            return RedirectToAction("");


        }


    }


}
