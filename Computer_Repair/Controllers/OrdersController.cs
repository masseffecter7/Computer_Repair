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
    public class OrdersController : Controller
    {
        private Computer_RepairContext db = new Computer_RepairContext();

        // GET: Orders
        [Authorize]
        public ActionResult Index(int? page, string currentFilter, string OrderFind = "")
        {
            if (OrderFind == "")
            {
                OrderFind = currentFilter;
            }
            else
            {
                page = 1;
            }
            ViewBag.CurrentFilter = OrderFind;

            if (OrderFind != null)
            {
                var orders = from m in db.Orders.Include(o => o.Customers).Include(o => o.Workers).Include(o => o.Accessories).Include(o => o.Services)
                             where m.OrderId.ToString().StartsWith(OrderFind)
                             select m;
                return View(orders.ToList().ToPagedList(page ?? 1, 20));
            }
            else
            {
                var orders = from m in db.Orders.Include(o => o.Customers).Include(o => o.Workers).Include(o => o.Accessories).Include(o => o.Services)
                             select m;
                return View(orders.ToList().ToPagedList(page ?? 1, 20));
            }
            
        }

        // GET: Orders/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // GET: Orders/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name_Surname");
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "Name");
            ViewBag.AccessorieId = new SelectList(db.Accessories, "AccessorieId", "AccessorieName");
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Service");
            return View();
        }

        // POST: Orders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderId,DateOfOrder,DateOfCompletion,AaccessorieId,CustomerId,Prepaid,Submitted,Completed,ServiceId,TotalCost,Guarantee,WorkerId")] Orders orders, string[] AccessorieId, string[] ServiceId)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name_Surname", orders.CustomerId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "Name", orders.WorkerId);
            ViewBag.AccessorieId = new SelectList(db.Accessories, "AccessorieId", "AccessorieName", orders.AccessorieId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Service", orders.ServiceId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name_Surname", orders.CustomerId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "Name", orders.WorkerId);
            ViewBag.AccessorieId = new SelectList(db.Accessories, "AccessorieId", "AccessorieName", orders.AccessorieId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Service", orders.ServiceId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,DateOfOrder,DateOfCompletion,AaccessorieId,CustomerId,Prepaid,Submitted,Completed,ServiceId,TotalCost,Guarantee,WorkerId")] Orders orders, string[] AccessorieId, string[] ServiceId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name_Surname", orders.CustomerId);
            ViewBag.WorkerId = new SelectList(db.Workers, "WorkerId", "Name", orders.WorkerId);
            ViewBag.AccessorieId = new SelectList(db.Accessories, "AccessorieId", "AccessorieName", orders.AccessorieId);
            ViewBag.ServiceId = new SelectList(db.Services, "ServiceId", "Service", orders.ServiceId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        // POST: Orders/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orders orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
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
