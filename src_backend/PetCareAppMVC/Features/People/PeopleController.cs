﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using PetCareAppMVC.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Infrastructure;
using Sieve.Models;
using PetCareAppMVC.Features;
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
    }


}
