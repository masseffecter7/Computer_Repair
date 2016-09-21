using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Computer_Repair.Models;

namespace Computer_Repair.Controllers
{
    public class AccessoriesController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: Accessories
        public ActionResult Index()
        {
            return View(db.Accessories.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            return View(accessorie);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accessories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccessorieId,KindId,Description,Price")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                db.Accessories.Add(accessorie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accessorie);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            return View(accessorie);
        }

        // POST: Accessories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccessorieId,KindId,Description,Price")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessorie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accessorie);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessorie accessorie = db.Accessories.Find(id);
            if (accessorie == null)
            {
                return HttpNotFound();
            }
            return View(accessorie);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessorie accessorie = db.Accessories.Find(id);
            db.Accessories.Remove(accessorie);
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
