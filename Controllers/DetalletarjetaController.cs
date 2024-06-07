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
    public class DetalletarjetaController : Controller
    {
        private CompanyJLSAEntities7 db = new CompanyJLSAEntities7();

        // GET: Detalletarjeta
        public ActionResult Index()
        {
            return View(db.Detalletarjeta.ToList());
        }

        // GET: Detalletarjeta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalletarjeta detalletarjeta = db.Detalletarjeta.Find(id);
            if (detalletarjeta == null)
            {
                return HttpNotFound();
            }
            return View(detalletarjeta);
        }

        // GET: Detalletarjeta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detalletarjeta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numerotarjeta,Nombretitular,Fechavencimiento,CVV")] Detalletarjeta detalletarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Detalletarjeta.Add(detalletarjeta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalletarjeta);
        }

        // GET: Detalletarjeta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalletarjeta detalletarjeta = db.Detalletarjeta.Find(id);
            if (detalletarjeta == null)
            {
                return HttpNotFound();
            }
            return View(detalletarjeta);
        }

        // POST: Detalletarjeta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numerotarjeta,Nombretitular,Fechavencimiento,CVV")] Detalletarjeta detalletarjeta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalletarjeta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalletarjeta);
        }

        // GET: Detalletarjeta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalletarjeta detalletarjeta = db.Detalletarjeta.Find(id);
            if (detalletarjeta == null)
            {
                return HttpNotFound();
            }
            return View(detalletarjeta);
        }

        // POST: Detalletarjeta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalletarjeta detalletarjeta = db.Detalletarjeta.Find(id);
            db.Detalletarjeta.Remove(detalletarjeta);
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
