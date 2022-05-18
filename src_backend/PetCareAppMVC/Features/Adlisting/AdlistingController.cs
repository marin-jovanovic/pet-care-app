using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using PetCareAppMVC.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Infrastructure;
using Sieve.Models;

using static DomainServices.Adlisting.Queries;


namespace PetCareAppMVC.Features.Adlisting
{
    public class AdlistingController:Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AdlistingController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Adlisting.Queries.GetAdlistingQuery();
            var data = await mediator.Send(query);
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }

}
