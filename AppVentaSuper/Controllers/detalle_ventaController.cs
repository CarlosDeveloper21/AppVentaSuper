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
    public class detalle_ventaController : Controller
    {
        private SuperEntities db = new SuperEntities();

        // GET: detalle_venta
        public ActionResult Index()
        {
            var detalle_venta = db.detalle_venta.Include(d => d.producto).Include(d => d.venta);
            return View(detalle_venta.ToList());
        }

        // GET: detalle_venta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // GET: detalle_venta/Create
        public ActionResult Create()
        {
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo");
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante");
            return View();
        }

        // POST: detalle_venta/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalle_venta,idventa,idproducto,cantidad,precio,descuento")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.detalle_venta.Add(detalle_venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_venta.idproducto);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // GET: detalle_venta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_venta.idproducto);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // POST: detalle_venta/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalle_venta,idventa,idproducto,cantidad,precio,descuento")] detalle_venta detalle_venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_venta.idproducto);
            ViewBag.idventa = new SelectList(db.venta, "idventa", "tipo_comprobante", detalle_venta.idventa);
            return View(detalle_venta);
        }

        // GET: detalle_venta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            if (detalle_venta == null)
            {
                return HttpNotFound();
            }
            return View(detalle_venta);
        }

        // POST: detalle_venta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_venta detalle_venta = db.detalle_venta.Find(id);
            db.detalle_venta.Remove(detalle_venta);
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
