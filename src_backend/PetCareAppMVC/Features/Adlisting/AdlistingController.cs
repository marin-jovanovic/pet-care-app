using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectMVC.Extensions;
using PetCareAppMVC.Features;
using Microsoft.AspNetCore.Mvc.Rendering;
using MediatR;
using Infrastructure;
using Sieve.Models;
using static DomainServices.Adlisting.Commands;

using static DomainServices.Adlisting.Queries;
using ProjectMVC.Features.Shared;

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

      

        [HttpPost]
        public async Task<IActionResult> Create(AdlistingViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = mapper.Map<AddAdlisting>(model);
                    int id = await mediator.Send(command);
                    TempData.Put(Constants.ActionStatus, new ActionStatus(true, $"{model.UserName} {model.Description} added"));
                    return RedirectToAction(nameof(Index), new { id });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.CompleteExceptionMessage());
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

    }

}
