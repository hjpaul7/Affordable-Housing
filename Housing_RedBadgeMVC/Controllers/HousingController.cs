using Housing_RedBadgeMVC.Data;
using Housing_RedBadgeMVC.Models;
using Housing_RedBadgeMVC.Models.HousingModels;
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

        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Housing
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HousingService(userId);
            var model = service.GetHousing();

            var housings = new SelectList(_db.Housings.ToList(), "HousingId", "Name");
            ViewBag.Housings = housings;

            return View(model);
        }

        // Get
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> housings = new SelectList(_db.Housings.ToList(), "HousingId", "Name");
            ViewBag.Housings = housings;
            return View();
        }


        public ActionResult RetrieveImage(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HousingService(userId);
            byte[] cover = service.GetImageFromDB(id);
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }


        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HousingCreate model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            if (!ModelState.IsValid)
            {
                return View(model);
            }
           var service = CreateHousingService();


           if (service.CreateHousing(file, model))
            {
                TempData["SaveResult"] = "The Housing was succesfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Housing could not be added");

            //return View(model);
            return RedirectToAction("Index");
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
                    HousingId = detail.HousingId,
                    Name = detail.Name,
                    Address = detail.Address,
                    UnitsAvailable = detail.UnitsAvailable,
                    AcceptVoucher = detail.AcceptVoucher,
                    SectionType = detail.SectionType,
                    Image = detail.Image
                };
            return View(model);
        }


        // Housing Edit - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HousingUpdate model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];

            if (!ModelState.IsValid) return View(model);

            if (model.HousingId != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateHousingService();

            if (service.UpdateHousing(file, model))
            {
                TempData["SaveResult"] = "Housing was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Housing could not be updated");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateHousingService();
            var model = svc.GetHousingDetail(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHousing(int id)
        {
            var service = CreateHousingService();
            service.DeleteHousing(id);

            TempData["SaveResult"] = "Housing was deleted";

            return RedirectToAction("Index");
        }


        private HousingService CreateHousingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HousingService(userId);
            return service;
        }
    }
}