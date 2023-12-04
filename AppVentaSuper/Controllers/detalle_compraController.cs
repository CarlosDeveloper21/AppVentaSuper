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
    public class detalle_compraController : Controller
    {
        private SuperEntities db = new SuperEntities();

        // GET: detalle_compra
        public ActionResult Index()
        {
            var detalle_compra = db.detalle_compra.Include(d => d.compra).Include(d => d.producto);
            return View(detalle_compra.ToList());
        }

        // GET: detalle_compra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_compra detalle_compra = db.detalle_compra.Find(id);
            if (detalle_compra == null)
            {
                return HttpNotFound();
            }
            return View(detalle_compra);
        }

        // GET: detalle_compra/Create
        public ActionResult Create()
        {
            ViewBag.idcompra = new SelectList(db.compra, "idcompra", "tipo_comprobante");
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo");
            return View();
        }

        // POST: detalle_compra/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "iddetalle_compra,idcompra,idproducto,cantidad,precio")] detalle_compra detalle_compra)
        {
            if (ModelState.IsValid)
            {
                db.detalle_compra.Add(detalle_compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcompra = new SelectList(db.compra, "idcompra", "tipo_comprobante", detalle_compra.idcompra);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_compra.idproducto);
            return View(detalle_compra);
        }

        // GET: detalle_compra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_compra detalle_compra = db.detalle_compra.Find(id);
            if (detalle_compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcompra = new SelectList(db.compra, "idcompra", "tipo_comprobante", detalle_compra.idcompra);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_compra.idproducto);
            return View(detalle_compra);
        }

        // POST: detalle_compra/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "iddetalle_compra,idcompra,idproducto,cantidad,precio")] detalle_compra detalle_compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcompra = new SelectList(db.compra, "idcompra", "tipo_comprobante", detalle_compra.idcompra);
            ViewBag.idproducto = new SelectList(db.producto, "idproducto", "codigo", detalle_compra.idproducto);
            return View(detalle_compra);
        }

        // GET: detalle_compra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detalle_compra detalle_compra = db.detalle_compra.Find(id);
            if (detalle_compra == null)
            {
                return HttpNotFound();
            }
            return View(detalle_compra);
        }

        // POST: detalle_compra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            detalle_compra detalle_compra = db.detalle_compra.Find(id);
            db.detalle_compra.Remove(detalle_compra);
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
