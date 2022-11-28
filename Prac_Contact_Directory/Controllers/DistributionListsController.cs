using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prac_Contact_Directory.Models;

namespace Prac_Contact_Directory.Controllers
{
    public class DistributionListsController : Controller
    {
        private RuchiPracDbContext db = new RuchiPracDbContext();

        // GET: DistributionLists
        public ActionResult Index(string Searching)
        {
            return View(db.DistributionList.Where (x=>x.DistributionListName.Contains (Searching) || Searching == null) .ToList());
        }
       

        // GET: DistributionLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionList distributionList = db.DistributionList.Find(id);
            if (distributionList == null)
            {
                return HttpNotFound();
            }
            return View(distributionList);
        }

        // GET: DistributionLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DistributionLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistributionListId,DistributionListName")] DistributionList distributionList)
        {
            if (ModelState.IsValid)
            {
                db.DistributionList.Add(distributionList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distributionList);
        }

        // GET: DistributionLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionList distributionList = db.DistributionList.Find(id);
            if (distributionList == null)
            {
                return HttpNotFound();
            }
            return View(distributionList);
        }

        // POST: DistributionLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistributionListId,DistributionListName")] DistributionList distributionList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distributionList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distributionList);
        }

        // GET: DistributionLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DistributionList distributionList = db.DistributionList.Find(id);
            if (distributionList == null)
            {
                return HttpNotFound();
            }
            return View(distributionList);
        }

        // POST: DistributionLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DistributionList distributionList = db.DistributionList.Find(id);
            db.DistributionList.Remove(distributionList);
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
