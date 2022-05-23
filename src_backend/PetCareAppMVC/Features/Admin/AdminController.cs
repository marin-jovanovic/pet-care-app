using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using ProjectMVC.Features.Shared;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;

using Sieve.Models;

//using Domain.Roles;
//using DomainServices.Roles;
//using static DomainServices.People.Commands;
//using static DomainServices.People.Commands;

using PetCareAppMVC.Features;
//using DomainServices.Adlisting;

//using PetCareAppMVC.Features.Listings;
//namespace PetCareAppMVC.Features.Login;

namespace PetCareAppMVC.Features.Listings
{
    public class AdminController : Controller
    {



        [HttpGet]
        public async Task<IActionResult> IndexAsync(SessionViewModel model)
        {
  
            return View();
        }

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AdminController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }


    


    }

}
