using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using PetCareAppMVC.Features.People;
using MediatR;

namespace ProjectMVC.Features.Home
{
  public class HomeController : Controller
  {

        //private readonly IMapper mapper;
        //private readonly IMediator mediator;

        //public HomeController(IMapper mapper, IMediator mediator)
        //{
        //    this.mapper = mapper;
        //    this.mediator = mediator;
        //}

        public IActionResult Index()
    {

            //try
            //{
        
            //        var command = AutoMapper.Map<DomainServices.People.Commands.AddPersonCommand>(new Domain.People.Person(
            //            23,
            //            "ime",
            //            "usrname",
            //            "mail",
            //            "zadnje ime",
            //            "pass",
            //            "mob",
            //            "sesija123"
            //            ));

            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //}

            //    var     model = mapper.Map<DomainServices.People.Commands.AddPersonCommand>(new Domain.People.Person(
            //            23,
            //            "ime",
            //            "usrname",
            //            "mail",
            //            "zadnje ime",
            //            "pass",
            //            "mob",
            //            "sesija123"
            //            ));

            ////inace ide await
            //mediator.Send(model);

            //Console.WriteLine("model", model);


            return View();




        }


        //[HttpGet]
        //public async Task<IActionResult> signup()
        //{

        //    Console.WriteLine("signup");

        //    return RedirectToAction("login");
            
        //    //PersonViewModel model = mapper.Map<PersonViewModel>(person);
        //    //    return View(model);
        //}

 
    }
}