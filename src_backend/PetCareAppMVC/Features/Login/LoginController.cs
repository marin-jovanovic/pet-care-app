using Microsoft.AspNetCore.Mvc;

namespace ProjectMVC.Features.Index
{
  public class LoginController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}