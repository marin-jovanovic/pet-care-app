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

namespace PetCareAppMVC.Features.People
{
    public class PeopleController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PeopleController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.People.Queries.GetPeopleQuery();
            var data = await mediator.Send(query);
            return View(data);
        }


    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }
  
   
        
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
        {
            var personQuery = new DomainServices.People.Queries.GetPersonQuery(id, IncludeProjects: false);
            var person = await mediator.Send(personQuery);
            if (person == null)
            {
                return NotFound();
            }
            else
            {
                PersonViewModel model = mapper.Map<PersonViewModel>(person);
                return View(model);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Delete(int username)
        {
            try
            {
                var command = new DeletePersonCommand(username);
                await mediator.Send(command);
                TempData.Put(Constants.ActionStatus, new ActionStatus(true, "Person deleted"));
            }
            catch (Exception ex)
            {
                TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = mapper.Map<AddPersonCommand>(model);
                    int id = await mediator.Send(command);
                    TempData.Put(Constants.ActionStatus, new ActionStatus(true, $"{model.userName} {model.email} added"));
                    return RedirectToAction(nameof(PersonViewModel), new { id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.CompleteExceptionMessage());
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
    }


}
