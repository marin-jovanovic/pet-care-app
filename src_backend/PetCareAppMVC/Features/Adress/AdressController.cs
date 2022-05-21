using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;

namespace PetCareAppMVC.Features.Adress
{
    public class AdressController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AdressController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Adress.Queries.GetAdressQuery();
            var data = await mediator.Send(query);
            return View(data);
        }
    }
}
