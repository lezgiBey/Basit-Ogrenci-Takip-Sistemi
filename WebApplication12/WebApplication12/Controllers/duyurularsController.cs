using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication12;

namespace WebApplication12.Controllers
{
    public class duyurularsController : Controller
    {
        private mezuntakipEntities db = new mezuntakipEntities();

        // GET: duyurulars
        public ActionResult Index()
        {
            var duyurular = db.duyurular.Include(d => d.users);
            return View(duyurular.ToList());
        }

        // GET: duyurulars/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            duyurular duyurular = db.duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // GET: duyurulars/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.YazarId = new SelectList(db.users, "id", "Ad");
            return View();
        }

        // POST: duyurulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Baslik,Icerik,Tarih,YazarId,SonaErmeTarihi,Yayinda,Resimyolu,DosyaYolu")] duyurular duyurular)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.duyurular.Add(duyurular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YazarId = new SelectList(db.users, "id", "Ad", duyurular.YazarId);
            return View(duyurular);
        }

        // GET: duyurulars/Edit/5
        public ActionResult Edit(short? id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            duyurular duyurular = db.duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            ViewBag.YazarId = new SelectList(db.users, "id", "Ad", duyurular.YazarId);
            return View(duyurular);
        }

        // POST: duyurulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Baslik,Icerik,Tarih,YazarId,SonaErmeTarihi,Yayinda,Resimyolu,DosyaYolu")] duyurular duyurular)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                db.Entry(duyurular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YazarId = new SelectList(db.users, "id", "Ad", duyurular.YazarId);
            return View(duyurular);
        }

        // GET: duyurulars/Delete/5
        public ActionResult Delete(short? id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            duyurular duyurular = db.duyurular.Find(id);
            if (duyurular == null)
            {
                return HttpNotFound();
            }
            return View(duyurular);
        }

        // POST: duyurulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            duyurular duyurular = db.duyurular.Find(id);
            db.duyurular.Remove(duyurular);
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
