using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CompanyJLSV7.Models;

namespace CompanyJLSV7.Controllers
{
    public class FormapagoController : Controller
    {
        private CompanyJLSAEntities7 db = new CompanyJLSAEntities7();

        // GET: Formapago
        public ActionResult Index()
        {
            var formapago = db.Formapago.Include(f => f.Detalletarjeta);
            return View(formapago.ToList());
        }

        // GET: Formapago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formapago formapago = db.Formapago.Find(id);
            if (formapago == null)
            {
                return HttpNotFound();
            }
            return View(formapago);
        }

        // GET: Formapago/Create
        public ActionResult Create()
        {
            ViewBag.Numerotarjeta = new SelectList(db.Detalletarjeta, "Numerotarjeta", "Nombretitular");
            return View();
        }

        // POST: Formapago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numeropago,Efectivo,Tarjeta,Numerotarjeta")] Formapago formapago)
        {
            if (ModelState.IsValid)
            {
                db.Formapago.Add(formapago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Numerotarjeta = new SelectList(db.Detalletarjeta, "Numerotarjeta", "Nombretitular", formapago.Numerotarjeta);
            return View(formapago);
        }

        // GET: Formapago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formapago formapago = db.Formapago.Find(id);
            if (formapago == null)
            {
                return HttpNotFound();
            }
            ViewBag.Numerotarjeta = new SelectList(db.Detalletarjeta, "Numerotarjeta", "Nombretitular", formapago.Numerotarjeta);
            return View(formapago);
        }

        // POST: Formapago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numeropago,Efectivo,Tarjeta,Numerotarjeta")] Formapago formapago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formapago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Numerotarjeta = new SelectList(db.Detalletarjeta, "Numerotarjeta", "Nombretitular", formapago.Numerotarjeta);
            return View(formapago);
        }

        // GET: Formapago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formapago formapago = db.Formapago.Find(id);
            if (formapago == null)
            {
                return HttpNotFound();
            }
            return View(formapago);
        }

        // POST: Formapago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formapago formapago = db.Formapago.Find(id);
            db.Formapago.Remove(formapago);
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
