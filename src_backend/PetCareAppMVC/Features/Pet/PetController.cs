using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;

namespace PetCareAppMVC.Features.Pet
{
    public class PetController:Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PetController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Pet.Queries.GetPetsQuery();
            var data = await mediator.Send(query);
            return View(data);
        }
    }
}
