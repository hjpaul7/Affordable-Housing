using Housing.Models.RatingModels;
using Housing.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Housing_RedBadgeMVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRating();

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
        public ActionResult Create(RatingCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateRatingService();

            if (service.CreateRating(model))
            {
                TempData["SaveResult"] = "The Safety Rating was succesfully created";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your Safety Rating could not be added");

            return View(model);
        }


        // Details
        public ActionResult Details(int id)
        {
            var service = CreateRatingService();
            var model = service.GetRatingDetail(id);

            return View(model);
        }

        // Edit
        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingDetail(id);
            var model =
                new RatingUpdate
                {
                    Rating = detail.Rating
                };
            return View(model);
        }


        // Edit - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingUpdate model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateRatingService();

            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Safety Rating was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Safety Rating could not be updated");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRatingService();
            service.DeleteRating(id);

            TempData["SaveResult"] = "Safety Rating was deleted";

            return RedirectToAction("Index");
        }


        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}