using Microsoft.AspNetCore.Mvc;

namespace ProjectMVC.Features.Home
{
  public class HomeController : Controller
  {
    public IActionResult Index()
    {
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