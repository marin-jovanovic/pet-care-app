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
            Domain.Listings dP1 = new Domain.Listings();
            IList<Domain.Listings> adlistings = new List<Domain.Listings>();
            adlistings.Clear();
            foreach (var ad in data2)
            {

                var petQ = new DomainServices.Pet.Queries.GetPetQuery(ad.PetId);
                var petd = await mediator.Send(petQ);

                var adrQ = new DomainServices.Adress.Queries.GetOneAdressQuery((int)ad.IdAdress);
                var adrd = await mediator.Send(adrQ);

                dP1.PetName = petd.PetName + " " + petd.Breed + " " + petd.PetType;
                dP1.IdAdress = (int)ad.IdAdress;
                dP1.PetId = ad.PetId;
                dP1.StartDate = ad.StartDate;
                dP1.Title = ad.Title;
                dP1.EndDate = ad.EndDate;
                dP1.Price = ad.Price;
                dP1.IsActiv = ad.IsActiv;

                dP1.PetName=petd.PetName;
                dP1.Size = petd.Size;
                dP1.Sex = petd.Sex;
                dP1.PetType = petd.PetType;
                dP1.Breed=petd.Breed;

                dP1.Adress1 = adrd.Adress1;
                dP1.City= adrd.City;
                dP1.Country = adrd.Country;
                dP1.PostalCode=adrd.PostalCode;
                dP1.IsHouse = adrd.IsHouse;
                dP1.Floor=adrd.Floor;

                adlistings.Add(dP1);
            }


            return View(adlistings);
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


            var query = new DomainServices.People.GetPersonByUserNameQuery(UserName, IncludeProjects: false);
            var data = await mediator.Send(query);
            IList<Domain.Listings> adlistings = new List<Domain.Listings>();
            if (data != null)
            {
                if (!(sessionId.Equals(data.SessionId)))
                {
                    return RedirectToAction("Index", "Home");
                }

                // if (sessionId != [select person.sessionId from person where person.username = username])
                //          return RedirectToAction("Index", "Home");

                //moras dohvatiti PersonRole i iz njih ucitati Idlisting i idUser-a
                var queryProle = new DomainServices.PersonRole.Queries.GetPersonRolesQuery();
                var datapr = await mediator.Send(queryProle);
                var personRoles = datapr.ToArray();
                

                var query5 = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
                var data5 = await mediator.Send(query5);

                foreach (var personRole in personRoles)
                {
                    foreach (var adlisting in data5.ToArray())
                    {
                        Domain.Listings dP=new Domain.Listings();   
                        if (data.PersonId == personRole.PersonId)
                        {
                            if (adlisting != null)
                            {
                                if (personRole.AdlistingId == adlisting.AdlistingId)
                                {
                                    var petQ = new DomainServices.Pet.Queries.GetPetQuery(adlisting.PetId);
                                    var petd = await mediator.Send(petQ);

                                    var adrQ = new DomainServices.Adress.Queries.GetOneAdressQuery((int)   adlisting.IdAdress);
                                    var adrd = await mediator.Send(adrQ);

                               
                                    dP.IdAdress =(int) adlisting.IdAdress;
                                    dP.PetId = adlisting.PetId;
                                    
                                    dP.StartDate = dP.StartDate;
                                    dP.Title=adlisting.Title;   
                                    dP.EndDate = adlisting.EndDate;
                                    dP.AdlistingDescription = adlisting.AdlistingDescription;
                                    dP.Price= adlisting.Price;
                                    dP.IsActiv=adlisting.IsActiv;


                                    dP.PetName = petd.PetName;
                                    dP.Size = petd.Size;
                                    dP.Sex = petd.Sex;
                                    dP.PetType = petd.PetType;
                                    dP.Breed = petd.Breed;

                                    dP.Adress1 = adrd.Adress1;
                                    dP.City = adrd.City;
                                    dP.Country = adrd.Country;
                                    dP.PostalCode = adrd.PostalCode;
                                    dP.IsHouse = adrd.IsHouse;
                                    dP.Floor = adrd.Floor;
                                    adlistings.Add(dP);
                                }
                            }
                        }
                    }




                }
                ViewBag.SessionId = sessionId;
                ViewBag.UserName = UserName;
                return View(adlistings);




            }


            // ovdje to mora bit filtrirano po ID-u usernamea
            ViewBag.SessionId = sessionId;
            ViewBag.UserName = UserName;


            var query1 = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
            var data2 = await mediator.Send(query1);
            Domain.Listings dP1 = new Domain.Listings();
            foreach (var ad in data2)
            {
               
                var petQ = new DomainServices.Pet.Queries.GetPetQuery(ad.PetId);
                var petd = await mediator.Send(petQ);

                var adrQ = new DomainServices.Adress.Queries.GetOneAdressQuery((int)ad.IdAdress);
                var adrd = await mediator.Send(adrQ);

                dP1.IdAdress = (int)ad.IdAdress;
                dP1.PetId = ad.PetId;
                dP1.StartDate = ad.StartDate;
                dP1.Title = ad.Title;
                dP1.EndDate = ad.EndDate;
                dP1.AdlistingDescription = ad.AdlistingDescription;
                dP1.Price = ad.Price;
                dP1.IsActiv = ad.IsActiv;
                dP1.PetName = petd.PetName;
                dP1.Size = petd.Size;
                dP1.Sex = petd.Sex;
                dP1.PetType = petd.PetType;
                dP1.Breed = petd.Breed;

                dP1.Adress1 = adrd.Adress1;
                dP1.City = adrd.City;
                dP1.Country = adrd.Country;
                dP1.PostalCode = adrd.PostalCode;
                dP1.IsHouse = adrd.IsHouse;
                dP1.Floor = adrd.Floor;

                adlistings.Add(dP1);
            }
            return View(adlistings);


        }


        [HttpGet]

        public async Task<IActionResult> Edit(string sessionId, string UserName, string adListingId)
        {
            var adressQuery = new Queries.GetAdlistQuery(Int32.Parse(adListingId), CancellationToken.None);
            var adress = await mediator.Send(adressQuery);
            if (adress == null)
            {
                return NotFound();
            }
            else
            {
                //ListingsViewModel model = mapper.Map<ListingsViewModel>(adress);
                return View(adress);
            }
        }
        [HttpPost]

        public async Task<IActionResult> Update(string sessionId, string UserName, string adListingId)
        {
            var adressQuery = new Queries.GetAdlistQuery(Int32.Parse(adListingId), CancellationToken.None);
            var adress = await mediator.Send(adressQuery);
            if (adress == null)
            {
                return NotFound();
            }
            else
            {
                //ListingsViewModel model = mapper.Map<ListingsViewModel>(adress);
                return View(adress);
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
            var query = new DomainServices.Adlisting.Queries.GetAdlistQuery(Int32.Parse(adListingId), new CancellationToken(false));
            var data = await mediator.Send(query);



            return  RedirectToPage(nameof(Edit), data);


        }

        public async Task<IActionResult> Create(string sessionId, string UserName)
        {


            return View();


        }



    }

}
