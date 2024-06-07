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
    public class PersonaController : Controller
    {
        private CompanyJLSAEntities7 db = new CompanyJLSAEntities7();

        // GET: Persona
        public ActionResult Index()
        {
            var persona = db.Persona.Include(p => p.Facturas1).Include(p => p.Rol);
            return View(persona.ToList());
        }

        // GET: Persona/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            ViewBag.Facturas = new SelectList(db.Facturas, "Facturas1", "Facturas1");
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "Nombrerol");
            return View();
        }

        // POST: Persona/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPersona,Nombre,Apellido,Tipodocumento,Correo,Telefono,Direccion,Tiporol")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                    db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Facturas = new SelectList(db.Facturas, "Facturas1", "Facturas1", persona.Facturas);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "Nombrerol", persona.idRol);
            return View(persona);
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.Facturas = new SelectList(db.Facturas, "Facturas1", "Facturas1", persona.Facturas);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "Nombrerol", persona.idRol);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPersona,Nombre,Apellido,Tipodocumento,Correo,Telefono,Direccion,Tiporol,idRol,Facturas")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Facturas = new SelectList(db.Facturas, "Facturas1", "Facturas1", persona.Facturas);
            ViewBag.idRol = new SelectList(db.Rol, "idRol", "Nombrerol", persona.idRol);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
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
