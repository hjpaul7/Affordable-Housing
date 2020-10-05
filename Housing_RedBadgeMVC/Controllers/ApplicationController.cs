using Housing.Services;
using Housing_RedBadgeMVC.Models.ApplicationModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Housing_RedBadgeMVC.Controllers
{
    [Authorize]
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplicationService(userId);
            var model = service.GetApplication();


            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateApplicationService();

            if (service.CreateApplication(model))
            {
                TempData["SaveResult"] = "The Application was succesfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Application could not be added");

            return View(model);
        }


        // Details
        public ActionResult Details(int id)
        {
            var service = CreateApplicationService();
            var model = service.GetApplicationDetail(id);

            return View(model);
        }


        // Edit
        public ActionResult Edit(int id)
        {
            var service = CreateApplicationService();
            var detail = service.GetApplicationDetail(id);
            var model =
                new ApplicationUpdate
                {
                    HousingId = detail.HousingId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    MonthlyIncome = detail.MonthlyIncome
                };
            return View(model);
        }

        
        // Edit - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ApplicationUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateApplicationService();

            if (service.UpdateApplication(model))
            {
                TempData["SaveResult"] = "Application was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Application could not be updated");
            return View(model);
        }


        // Delete by Id
        [[HttpPost]]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteApplication(int id)
        {
            var service = CreateApplicationService();
            service.DeleteApplication(id);

            TempData["SaveResult"] = "Application was deleted";

            return RedirectToAction("Index");
        }


        private ApplicationService CreateApplicationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ApplicationService(userId);
            return service;
        }
    }
}