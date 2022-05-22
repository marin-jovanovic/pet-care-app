using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MediatR;
using static DomainServices.Adress.Commands;
using ProjectMVC.Features.Shared;
using ProjectMVC.Extensions;

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
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]

        //public async Task<IActionResult> Edit(int id)
        public async Task<IActionResult> Edit(string sessionId, string UserName, int adListingId)
        {
            Console.WriteLine("edit");
            var adressQuery = new DomainServices.Adress.Queries.GetOneAdressQuery(adListingId);
            var adress = await mediator.Send(adressQuery);
            if (adress == null)
            {
                return NotFound();
            }
            else
            {
                AdressViewModel model = mapper.Map<AdressViewModel>(adress);
                return RedirectToAction("Index", "Pet");
                
                return View(model);


            }
        }






        [HttpPost]
        public async Task<IActionResult> Edit(AdressViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var command = mapper.Map<UpdateAdressCommand>(model);
                    await mediator.Send(command);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    //ModelState.AddModelError(string.Empty, ex.CompleteExceptionMessage());
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        //public async Task<ActionResult> Delete(int id)
        public async Task<ActionResult> Delete(string sessionId, string UserName, int adListingId)
        {
            try
            {
                var command = new DeleteAdressCommand(adListingId);
                await mediator.Send(command);
                ViewBag.SessionId = "brisanje je uspjelo";

                //TempData.Put(Constants.ActionStatus, new ActionStatus(true, "Person deleted"));
            }
            catch (Exception ex)
            {
                ViewBag.SessionId = "brisanje nije uspjelo";
                //TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
            }
            //return RedirectToAction(nameof(Index));



            return View();

        }






        public async Task<IActionResult> Create(AdressViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var adrQuery = new DomainServices.Adress.Queries.GetAdressQuery();
                    var adr = await mediator.Send(adrQuery);
                    model.AdressId = adr.LastOrDefault().AdressId + 1;
                    var command = mapper.Map<AddAdressCommand>(model);
                    int id = await mediator.Send(command);
                    TempData.Put(Constants.ActionStatus, new ActionStatus(true, $"{model.Adress1} added"));
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
