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
    public class FacturasController : Controller
    {
        private CompanyJLSAEntities  db = new CompanyJLSAEntities();

        // GET: Facturas
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Bodega).Include(f => f.DetalleFactura).Include(f => f.Formapago);
            return View(facturas.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Bodega, "idProducto", "Nombreproducto");
            ViewBag.Codigo = new SelectList(db.DetalleFactura, "Codigo", "Valor");
            ViewBag.Numeropago = new SelectList(db.Formapago, "Numeropago", "Efectivo");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Facturas1,Fecha,Codigo,Numeropago,idProducto")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(facturas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.Bodega, "idProducto", "Nombreproducto", facturas.idProducto);
            ViewBag.Codigo = new SelectList(db.DetalleFactura, "Codigo", "Valor", facturas.Codigo);
            ViewBag.Numeropago = new SelectList(db.Formapago, "Numeropago", "Efectivo", facturas.Numeropago);
            return View(facturas);
        }

        // GET: Facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.Bodega, "idProducto", "Nombreproducto", facturas.idProducto);
            ViewBag.Codigo = new SelectList(db.DetalleFactura, "Codigo", "Valor", facturas.Codigo);
            ViewBag.Numeropago = new SelectList(db.Formapago, "Numeropago", "Efectivo", facturas.Numeropago);
            return View(facturas);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Facturas1,Fecha,Codigo,Numeropago,idProducto")] Facturas facturas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.Bodega, "idProducto", "Nombreproducto", facturas.idProducto);
            ViewBag.Codigo = new SelectList(db.DetalleFactura, "Codigo", "Valor", facturas.Codigo);
            ViewBag.Numeropago = new SelectList(db.Formapago, "Numeropago", "Efectivo", facturas.Numeropago);
            return View(facturas);
        }

        // GET: Facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturas facturas = db.Facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facturas facturas = db.Facturas.Find(id);
            db.Facturas.Remove(facturas);
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
