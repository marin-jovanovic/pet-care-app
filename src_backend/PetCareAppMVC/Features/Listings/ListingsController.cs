using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using ProjectMVC.Features.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;

using Sieve.Models;

//using Domain.Roles;
//using DomainServices.Roles;
using static DomainServices.People.Commands;
//using static DomainServices.People.Commands;

using PetCareAppMVC.Features;

//using PetCareAppMVC.Features.Listings;
//namespace PetCareAppMVC.Features.Login;

namespace PetCareAppMVC.Features.Listings
{
    public class ListingsController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> IndexAsync(SessionViewModel model)
        {
            // sad tu ocu da se napravi select iz baze
          
            //return View("../listings/index", data2);

            Console.WriteLine("session id", model.sessionId);
            ViewData["SessionId"] = model.sessionId;


            var query1 = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
            var data2 = await mediator.Send(query1);
            return View(data2);
        }

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public ListingsController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }


    }

}
