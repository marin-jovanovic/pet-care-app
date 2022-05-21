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
        public async Task<ActionResult> SignupCheck(SignupViewModel model)

         {
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


        }


    }


}
