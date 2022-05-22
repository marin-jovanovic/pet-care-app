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
using DomainServices.Adlisting;

//using PetCareAppMVC.Features.Listings;
//namespace PetCareAppMVC.Features.Login;

namespace PetCareAppMVC.Features.Listings
{
    public class ListingsController : Controller
    {

        private async Task PrepareListOfPet()
        {
            var petsQuery = new DomainServices.Pet.Queries.GetPetsQuery();
            var pets = await mediator.Send(petsQuery);
            ViewBag.ProjectTypes = new SelectList(pets,
              dataValueField: nameof(Domain.Pet.PetId),
              dataTextField: nameof(Domain.Pet.Breed));
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync(SessionViewModel model)
        {
            // sad tu ocu da se napravi select iz baze
          
            //return View("../listings/index", data2);

            Console.WriteLine("session id", model.sessionId);
            Console.WriteLine("session username", model.UserName);

            // obrisi kasnije
            ViewData["SessionId"] = model.sessionId;

            ViewBag.SessionId = model.sessionId;
            ViewBag.UserName = model.UserName;

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

        public async Task<IActionResult> MyListings(string sessionId, string UserName)
        {


            var query = new DomainServices.People.GetPersonByUserNameQuery(UserName, IncludeProjects:false);
            var data = await mediator.Send(query);
            if(data != null)
            {
                if (!(sessionId.Equals(data.SessionId)))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            // if (sessionId != [select person.sessionId from person where person.username = username])
            //          return RedirectToAction("Index", "Home");


            // ovdje to mora bit filtrirano po ID-u usernamea
            ViewBag.SessionId = sessionId;
            ViewBag.UserName = UserName;
            var query1 = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
            var data2 = await mediator.Send(query1);
            return View(data2);


        }


        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var adressQuery = new  Queries.GetAdlistQuery(id, CancellationToken.None);
            var adress = await mediator.Send(adressQuery);
            if (adress == null)
            {
                return NotFound();
            }
            else
            {
                ListingsViewModel model = mapper.Map<ListingsViewModel>(adress);
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(string sessionId, string UserName, string adListingId)
        {

            //'&AdlistingId='+
            //objJson[i].adName['adlisting id']+

            return View();


        }



        public async Task<IActionResult> Manage(string sessionId, string UserName, string adListingId)
        {

            return View();


        }

        public async Task<IActionResult> Create(string sessionId, string UserName)
        {

            return View();


        }



    }

}
