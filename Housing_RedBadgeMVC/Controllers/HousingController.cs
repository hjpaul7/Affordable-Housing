using Housing_RedBadgeMVC.Models;
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
    public class HousingController : Controller
    {
        // GET: Housing
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HousingService(userId);
            var model = service.GetHousing();

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
        public ActionResult Create(HousingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
           var service = CreateHousingService();

           if (service.CreateHousing(model))
            {
                TempData["SaveResult"] = "The Housing was succesfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Housing could not be added");

            return View(model);
        }


        // Housing Details
        public ActionResult Details(int id)
        {
            var service = CreateHousingService();
            var model = service.GetHousingDetail(id);

            return View(model);
        }

        // Housing Edit
        public ActionResult Edit(int id)
        {
            var service = CreateHousingService();
            var detail = service.GetHousingDetail(id);
            var model =
                new HousingUpdate
                {
                    Name = detail.Name,
                    Address = detail.Address,
                    UnitsAvailable = detail.UnitsAvailable,
                    AcceptVoucher = detail.AcceptVoucher,
                    SectionType = detail.SectionType
                };
            return View(model);
        }


        // Housing Edit - Post
        public ActionResult Edit(int id, HousingDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateHousingService();

            if (service.)
        }


        private HousingService CreateHousingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HousingService(userId);
            return service;
        }
    }
}