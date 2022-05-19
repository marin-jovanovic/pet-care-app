using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;

namespace PetCareAppMVC.Features.Pettype
{
    public class PettypeController:Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PettypeController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Pettype.Queries.GetPettypesQuery();
            var data = await mediator.Send(query);
            return View(data);
        }
    }
}
