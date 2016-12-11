using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computer_Repair.Models;
using PagedList;
using PagedList.Mvc;

namespace Computer_Repair.Controllers
{
    public class AccessoriesController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: Accessories
        [Authorize]
        public ActionResult Index(int? page, string currentFilter1 = "", string currentFilter2 = "", string currentFilter3 = "", string CountryFind = "", string GuaranteeFind = "", string KindFind = "")
        {
            if (GuaranteeFind == "" && CountryFind == "" && KindFind == "")
            {
                GuaranteeFind = currentFilter1;
                CountryFind = currentFilter2;
                KindFind = currentFilter3;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter1 = GuaranteeFind;
            ViewBag.CurrentFilter2 = CountryFind;
            ViewBag.CurrentFilter3 = KindFind;

            var accessories = from m in db.Accessories.Include(a => a.KindsOfAccessories)
                              select m;
            if (GuaranteeFind != "")
                accessories = accessories.Include(a => a.KindsOfAccessories).Where(m => m.Guarantee.StartsWith(GuaranteeFind));
            if (CountryFind != "")
                accessories = accessories.Include(a => a.KindsOfAccessories).Where(m => m.Country.StartsWith(CountryFind));
            if (KindFind != "")
                accessories = accessories.Include(a => a.KindsOfAccessories).Where(m => m.KindsOfAccessories.Kind.StartsWith(KindFind));
            return View(accessories.ToList().ToPagedList(page ?? 1, 20));
        }

        // GET: Accessories/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // GET: Accessories/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind");
            return View();
        }

        // POST: Accessories/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessorieId,KindId,AccessorieName,Firm,Country,ReleaseDate,Characteristics,Guarantee,Description,Price")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessories);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // GET: Accessories/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // POST: Accessories/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessorieId,KindId,AccessorieName,Firm,Country,ReleaseDate,Characteristics,Guarantee,Description,Price")] Accessories accessories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindId = new SelectList(db.KindsOfAccessories, "KindId", "Kind", accessories.KindId);
            return View(accessories);
        }

        // GET: Accessories/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories accessories = db.Accessories.Find(id);
            if (accessories == null)
            {
                return HttpNotFound();
            }
            return View(accessories);
        }

        // POST: Accessories/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories accessories = db.Accessories.Find(id);
            db.Accessories.Remove(accessories);
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
