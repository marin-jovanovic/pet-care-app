using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;

namespace PetCareAppMVC.Features.Period
{
    public class PeriodController : Controller
    {
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public PeriodController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new DomainServices.Period.Queries.GetPeriodsQuery();
            var data = await mediator.Send(query);
            return View(data);
        }
    }
}
