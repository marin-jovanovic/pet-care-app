﻿using Microsoft.AspNetCore.Mvc;

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