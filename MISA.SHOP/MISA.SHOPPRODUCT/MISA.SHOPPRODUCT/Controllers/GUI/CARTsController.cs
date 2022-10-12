using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MISA.SHOPPRODUCT.Models;

namespace MISA.SHOPPRODUCT.Controllers.GUI
{
    public class CARTsController : Controller
    {
        private SHOP db = new SHOP();

        // GET: CARTs
        public ActionResult Index()
        {
            var cARTs = db.CARTs.Include(c => c.CLIENT).Include(c => c.PRODUCT);
            return View(cARTs.ToList());
        }

        // GET: CARTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // GET: CARTs/Create
        public ActionResult Create()
        {
            ViewBag.IDCE = new SelectList(db.CLIENTs, "IDCE", "US");
            ViewBag.IDPD = new SelectList(db.PRODUCTs, "IDPD", "NAMEPD");
            return View();
        }

        // POST: CARTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDCE,IDPD,SELLNUMBER,DATEBUY,STATUSCLIENT")] CART cART)
        {
            if (ModelState.IsValid)
            {
                db.CARTs.Add(cART);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCE = new SelectList(db.CLIENTs, "IDCE", "US", cART.IDCE);
            ViewBag.IDPD = new SelectList(db.PRODUCTs, "IDPD", "NAMEPD", cART.IDPD);
            return View(cART);
        }

        // GET: CARTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCE = new SelectList(db.CLIENTs, "IDCE", "US", cART.IDCE);
            ViewBag.IDPD = new SelectList(db.PRODUCTs, "IDPD", "NAMEPD", cART.IDPD);
            return View(cART);
        }

        // POST: CARTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDCE,IDPD,SELLNUMBER,DATEBUY,STATUSCLIENT")] CART cART)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cART).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCE = new SelectList(db.CLIENTs, "IDCE", "US", cART.IDCE);
            ViewBag.IDPD = new SelectList(db.PRODUCTs, "IDPD", "NAMEPD", cART.IDPD);
            return View(cART);
        }

        // GET: CARTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CART cART = db.CARTs.Find(id);
            if (cART == null)
            {
                return HttpNotFound();
            }
            return View(cART);
        }

        // POST: CARTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CART cART = db.CARTs.Find(id);
            db.CARTs.Remove(cART);
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
