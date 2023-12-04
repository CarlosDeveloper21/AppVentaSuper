using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppVentaSuper;

namespace AppVentaSuper.Controllers
{
    public class compraController : Controller
    {
        private SuperEntities db = new SuperEntities();

        // GET: compra
        public ActionResult Index()
        {
            var compra = db.compra.Include(c => c.proveedor).Include(c => c.usuario);
            return View(compra.ToList());
        }

        // GET: compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // GET: compra/Create
        public ActionResult Create()
        {
            ViewBag.idproveedor = new SelectList(db.proveedor, "idproveedor", "tipo_proveedor");
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre");
            return View();
        }

        // POST: compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcompra,idproveedor,idusuario,tipo_comprobante,serie_comprobante,num_comprobante,fecha,impuesto,total,estado")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.compra.Add(compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idproveedor = new SelectList(db.proveedor, "idproveedor", "tipo_proveedor", compra.idproveedor);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", compra.idusuario);
            return View(compra);
        }

        // GET: compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idproveedor = new SelectList(db.proveedor, "idproveedor", "tipo_proveedor", compra.idproveedor);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", compra.idusuario);
            return View(compra);
        }

        // POST: compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcompra,idproveedor,idusuario,tipo_comprobante,serie_comprobante,num_comprobante,fecha,impuesto,total,estado")] compra compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idproveedor = new SelectList(db.proveedor, "idproveedor", "tipo_proveedor", compra.idproveedor);
            ViewBag.idusuario = new SelectList(db.usuario, "idusuario", "nombre", compra.idusuario);
            return View(compra);
        }

        // GET: compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compra compra = db.compra.Find(id);
            if (compra == null)
            {
                return HttpNotFound();
            }
            return View(compra);
        }

        // POST: compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            compra compra = db.compra.Find(id);
            db.compra.Remove(compra);
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
