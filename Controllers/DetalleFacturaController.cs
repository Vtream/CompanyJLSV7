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
    public class DetalleFacturaController : Controller
    {
        private CompanyJLSAEntities db = new CompanyJLSAEntities();

        // GET: DetalleFactura
        public ActionResult Index()
        {
            var detalleFactura = db.DetalleFactura.Include(d => d.Plato);
            return View(detalleFactura.ToList());
        }

        // GET: DetalleFactura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Create
        public ActionResult Create()
        {
            ViewBag.Codigoplato = new SelectList(db.Plato, "Codigoplato", "Nombre");
            return View();
        }

        // POST: DetalleFactura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Cantidad,Valor,Codigoplato")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFactura.Add(detalleFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigoplato = new SelectList(db.Plato, "Codigoplato", "Nombre", detalleFactura.Codigoplato);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigoplato = new SelectList(db.Plato, "Codigoplato", "Nombre", detalleFactura.Codigoplato);
            return View(detalleFactura);
        }

        // POST: DetalleFactura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Cantidad,Valor,Codigoplato")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigoplato = new SelectList(db.Plato, "Codigoplato", "Nombre", detalleFactura.Codigoplato);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFactura.Find(id);
            db.DetalleFactura.Remove(detalleFactura);
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
