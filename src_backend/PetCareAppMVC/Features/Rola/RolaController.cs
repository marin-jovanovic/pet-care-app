using Domain;
using DomainServices.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetCareAppMVC;
using ProjectMVC.Extensions;
using ProjectMVC.Features.Shared;

namespace ProjectMVC.Features.Rola
{
  public class RolaController : Controller
  {
    private readonly IMediator mediator;

    public RolaController(IMediator mediator)
    {
      this.mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
      var query = new Queries.GetRolesQuery();
      var data = await mediator.Send(query);
      return View(data);
    } 

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Domain.Role model)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var command = new DomainServices.Role.Commands.CreateRoleCommand(model.RoleName);
          var data = await mediator.Send(command);
          return RedirectToAction(nameof(Index));
        }
        catch (Exception ex) {
          ModelState.AddModelError(string.Empty, ex.CompleteExceptionMessage());
          return View(model);
        }
      }
      else
      {
        return View(model);
      }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
      var query = new Queries.GetRoleQuery(id);
      var role = await mediator.Send(query);
      if (role == null)
      {
        return NotFound();
      }
      else
      {
        return View(role);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Domain.Role model)
    {
      if (ModelState.IsValid)
      {
        try
        {
          var command = new Commands.UpdateRole
          {
            RoleId = model.RoleId,
            RoleName = model.RoleName
          };
          var data = await mediator.Send(command);
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

    [HttpPost]
    public async Task<ActionResult> Delete(int id)
    {
      try
      {
        var command = new Commands.DeleteRole(id);
        var data = await mediator.Send(command);
        TempData.Put(Constants.ActionStatus, new ActionStatus(true, "Role deleted"));        
      }
      catch (Exception ex)
      {
        TempData.Put(Constants.ActionStatus, new ActionStatus(false, ex.CompleteExceptionMessage()));
      }
      return RedirectToAction(nameof(Index));
    }
  }
}
