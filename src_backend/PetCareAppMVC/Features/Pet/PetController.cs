using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using static DomainServices.Pet.Commands;
using ProjectMVC.Features.Shared;
using ProjectMVC.Extensions;
using PetCareAppMVC.Features;

namespace PetCareAppMVC.Features.Pet
{
    public class PetController : Controller
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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> Edit(string sessionId,string UserName, int adListingId)
        {
            //sessionId = '+
            //    sessionid +
            //    '&UserName=' +
            //    username +
            //    '&adListingId

            Console.WriteLine("edit", adListingId);

            var PetQuery = new DomainServices.Pet.Queries.GetPetQuery(adListingId);
            var Pet = await mediator.Send(PetQuery);
            if (Pet == null)
            {
                return NotFound();
            }
            else
            {
                PetViewModel model = mapper.Map<PetViewModel>(Pet);
                return View(model);
            }
        }


        [HttpGet]
        public async Task<ActionResult> Delete(string sessionId, string UserName, int adListingId)
        {
            
            //var command = new DeletePet(adListingId);
            //await mediator.Send(command);
            try
            {
                var command = new DeletePet(adListingId);
                await mediator.Send(command);

                ViewBag.SessionId = "brisanje je uspjelo";

                //TempData.Put(Constants.ActionStatus, new ActionStatus(true, "Pet deleted"));
            }
            catch (Exception ex)
            {
                ViewBag.SessionId = "brisanje nije uspjelo";
                //TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
            }

            //return RedirectToAction("Index", "Pet");
            return View();

            //return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = mapper.Map<UpdatePet>(model);
                    await mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var command = new DeletePet(id);
                await mediator.Send(command);
                TempData.Put(Constants.ActionStatus, new ActionStatus(true, "Pet deleted"));
            }
            catch (Exception ex)
            {
                TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Create(PetViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var adrQuery = new DomainServices.Pet.Queries.GetPetsQuery();
                    var adr = await mediator.Send(adrQuery);
                    model.PetId = adr.LastOrDefault().PetId + 1;
                    var command = mapper.Map<CreatePet>(model);
                    int id = await mediator.Send(command);
                    TempData.Put(Constants.ActionStatus, new ActionStatus(true, $"{model.PetType} added"));
                    return RedirectToAction(nameof(Index));
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
