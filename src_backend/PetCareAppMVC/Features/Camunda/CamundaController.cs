namespace PetCareAppMVC.Features.Camunda
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DomainModel.Camunda;
    using global::PetCareAppMVC.Util;
    using Microsoft.AspNetCore.Mvc;
    

    namespace Camunda
    {
        public class CamundaController : Controller
        {
            private const string CoordinatorsGroup = "Coordinators";

            public async Task<IActionResult> Index(string user)
            {
                DashboardData data = new DashboardData();
                data.ProcessInstances = await CamundaUtil.GetReviews();
                data.MyTasks = await CamundaUtil.GetTasks(user);
                if (await CamundaUtil.IsUserInGroup(user, CoordinatorsGroup))
                {
                    data.CoordinatorsTasks = await CamundaUtil.UnAssignedGroupTasks(CoordinatorsGroup);
                }

                return View(data);
            }

            [HttpPost]
            public async Task<IActionResult> ApplyForReview(string user, string pid)
            {
                await CamundaUtil.ApplyForReview(pid, user);
                return RedirectToAction(nameof(Index), new { user });
            }

            [HttpPost]
            public async Task<IActionResult> PickTask(string user, string taskId)
            {
                await CamundaUtil.PickTask(taskId, user);
                return RedirectToAction(nameof(Index), new { user });
            }

            [HttpPost]
            public async Task<IActionResult> FinishTask(string user, string taskId)
            {
                await CamundaUtil.FinishTask(taskId);
                return RedirectToAction(nameof(Index), new { user });
            }

            [HttpPost]
            public async Task<IActionResult> FinishReview(string user, string taskId, string comment, bool ok)
            {
                await CamundaUtil.FinishReview(taskId, comment, ok);
                return RedirectToAction(nameof(Index), new { user });
            }

            [HttpPost]
            public async Task<IActionResult> AssignReviewer(string user, string reviewer, string taskId)
            {
                await CamundaUtil.AssignReviewer(taskId, reviewer);
                return RedirectToAction(nameof(Index), new { user });
            }


            [HttpGet]
            public IActionResult Start(string user)
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Start(string user, int id)
            {
                var pid = await CamundaUtil.StartReviewProcess(id, user);

                return RedirectToAction(nameof(Index), new { user });
            }

            public async Task<ActionResult<string>> Diagram()
            {
                var xml = await CamundaUtil.GetXmlDefinition();
                return xml;
            }


        }
    }
}
