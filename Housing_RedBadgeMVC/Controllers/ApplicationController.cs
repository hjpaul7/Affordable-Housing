using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models.ApplicationModels;
using Housing_RedBadgeMVC.Services;
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
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Application
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var service = new ApplicationService(userId);
            var model = service.GetApplication();


            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            var housings = new SelectList(_db.Housings.ToList(), "HousingId", "Name");
            ViewBag.Housings = housings;
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
            var housing = _db.Housings.Find(model.HousingId);

            var service = CreateApplicationService();

            if (service.CreateApplication(model))
            {
                housing.UnitsAvailable -= model.UnitsRequested;
                if(_db.SaveChanges() == 1)
                {

                TempData["SaveResult"] = "The Application was succesfully created";
                return RedirectToAction("Index");
                }
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


        // Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateApplicationService();
            var model = svc.GetApplicationDetail(id);

            return View(model);
        }


        // Delete by Id
        [HttpPost]
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
            var userId = User.Identity.GetUserId();
            var service = new ApplicationService(userId);
            return service;
        }
    }
}