using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ResturantOnline.Models;

namespace ResturantOnline.Controllers
{
    public class ResturantReviewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ResturantReviews
        public ActionResult Index()
        {
            return View(db.ResturantReviews.ToList());
        }

        // GET: ResturantReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResturantReview resturantReview = db.ResturantReviews.Find(id);
            if (resturantReview == null)
            {
                return HttpNotFound();
            }
            return View(resturantReview);
        }

        // GET: ResturantReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResturantReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,City,Country,Rating")] ResturantReview resturantReview)
        {
            if (ModelState.IsValid)
            {
                db.ResturantReviews.Add(resturantReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resturantReview);
        }

        // GET: ResturantReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResturantReview resturantReview = db.ResturantReviews.Find(id);
            if (resturantReview == null)
            {
                return HttpNotFound();
            }
            return View(resturantReview);
        }

        // POST: ResturantReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,City,Country,Rating")] ResturantReview resturantReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resturantReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resturantReview);
        }

        // GET: ResturantReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResturantReview resturantReview = db.ResturantReviews.Find(id);
            if (resturantReview == null)
            {
                return HttpNotFound();
            }
            return View(resturantReview);
        }

        // POST: ResturantReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResturantReview resturantReview = db.ResturantReviews.Find(id);
            db.ResturantReviews.Remove(resturantReview);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
