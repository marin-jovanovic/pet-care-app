using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;

namespace PetCareAppMVC.Features.Location
{
    public class LocationController:Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public LocationController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Location.Queries.GetLocationsQuery();
            var data = await mediator.Send(query);
            return View(data);
        }
    }
}
