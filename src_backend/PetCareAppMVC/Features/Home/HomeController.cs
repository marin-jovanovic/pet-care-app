using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using PetCareAppMVC.Features.People;
using MediatR;

namespace ProjectMVC.Features.Home
{
  public class HomeController : Controller
  {


        public IActionResult Index()
   {



            return View();




        }


 
    }
}