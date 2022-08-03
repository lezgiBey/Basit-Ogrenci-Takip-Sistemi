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
    public class usersController : Controller
    {
        private mezuntakipEntities db = new mezuntakipEntities();

        // GET: users
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            var users = db.users.Include(u => u.askerlikdurumlari).Include(u => u.bolumler).Include(u => u.calismadurumlari).Include(u => u.cinsiyetler).Include(u => u.iller).Include(u => u.medenihaller).Include(u => u.ogrenimturleri).Include(u => u.programlar).Include(u => u.roller);
            return View(users.ToList());
        }

        // GET: users/Details/5
        public ActionResult Details(int? id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.AskerlikDurumId = new SelectList(db.askerlikdurumlari, "id", "askerlikdurum");
            ViewBag.BolumId = new SelectList(db.bolumler, "id", "bolumadi");
            ViewBag.CalismaDurumId = new SelectList(db.calismadurumlari, "id", "calismadurum");
            ViewBag.CinsiyetId = new SelectList(db.cinsiyetler, "id", "cinsiyet");
            ViewBag.IllerId = new SelectList(db.iller, "id", "sehiradi");
            ViewBag.MedeniHalId = new SelectList(db.medenihaller, "id", "medenihal");
            ViewBag.OgretimTurId = new SelectList(db.ogrenimturleri, "id", "ogrenimtur");
            ViewBag.ProgramId = new SelectList(db.programlar, "id", "programadi");
            ViewBag.RolId = 2;

            return View();

        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ad,Soyad,Eposta,Sifre,Telefon,IllerId,CinsiyetId,RolId,Dogumtarihi,Uyruk,MedeniHalId,WebSitesi,Linkedin,AskerlikDurumId,ProgramId,OgretimTurId,GirisYili,MezunYili,DiplomaNotu,CalismaDurumId,BolumId")] users users)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AskerlikDurumId = new SelectList(db.askerlikdurumlari, "id", "askerlikdurum", users.AskerlikDurumId);
            ViewBag.BolumId = new SelectList(db.bolumler, "id", "bolumadi", users.BolumId);
            ViewBag.CalismaDurumId = new SelectList(db.calismadurumlari, "id", "calismadurum", users.CalismaDurumId);
            ViewBag.CinsiyetId = new SelectList(db.cinsiyetler, "id", "cinsiyet", users.CinsiyetId);
            ViewBag.IllerId = new SelectList(db.iller, "id", "sehiradi", users.IllerId);
            ViewBag.MedeniHalId = new SelectList(db.medenihaller, "id", "medenihal", users.MedeniHalId);
            ViewBag.OgretimTurId = new SelectList(db.ogrenimturleri, "id", "ogrenimtur", users.OgretimTurId);
            ViewBag.ProgramId = new SelectList(db.programlar, "id", "programadi", users.ProgramId);
            ViewBag.RolId = 2;
            return View(users);
        }

        // GET: users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            ViewBag.AskerlikDurumId = new SelectList(db.askerlikdurumlari, "id", "askerlikdurum", users.AskerlikDurumId);
            ViewBag.BolumId = new SelectList(db.bolumler, "id", "bolumadi", users.BolumId);
            ViewBag.CalismaDurumId = new SelectList(db.calismadurumlari, "id", "calismadurum", users.CalismaDurumId);
            ViewBag.CinsiyetId = new SelectList(db.cinsiyetler, "id", "cinsiyet", users.CinsiyetId);
            ViewBag.IllerId = new SelectList(db.iller, "id", "sehiradi", users.IllerId);
            ViewBag.MedeniHalId = new SelectList(db.medenihaller, "id", "medenihal", users.MedeniHalId);
            ViewBag.OgretimTurId = new SelectList(db.ogrenimturleri, "id", "ogrenimtur", users.OgretimTurId);
            ViewBag.ProgramId = new SelectList(db.programlar, "id", "programadi", users.ProgramId);
            ViewBag.RolId = new SelectList(db.roller, "id", "rol", users.RolId);
            return View(users);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Ad,Soyad,Eposta,Sifre,Telefon,IllerId,CinsiyetId,RolId,Dogumtarihi,Uyruk,MedeniHalId,WebSitesi,Linkedin,AskerlikDurumId,ProgramId,OgretimTurId,GirisYili,MezunYili,DiplomaNotu,CalismaDurumId,BolumId")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AskerlikDurumId = new SelectList(db.askerlikdurumlari, "id", "askerlikdurum", users.AskerlikDurumId);
            ViewBag.BolumId = new SelectList(db.bolumler, "id", "bolumadi", users.BolumId);
            ViewBag.CalismaDurumId = new SelectList(db.calismadurumlari, "id", "calismadurum", users.CalismaDurumId);
            ViewBag.CinsiyetId = new SelectList(db.cinsiyetler, "id", "cinsiyet", users.CinsiyetId);
            ViewBag.IllerId = new SelectList(db.iller, "id", "sehiradi", users.IllerId);
            ViewBag.MedeniHalId = new SelectList(db.medenihaller, "id", "medenihal", users.MedeniHalId);
            ViewBag.OgretimTurId = new SelectList(db.ogrenimturleri, "id", "ogrenimtur", users.OgretimTurId);
            ViewBag.ProgramId = new SelectList(db.programlar, "id", "programadi", users.ProgramId);
            ViewBag.RolId = new SelectList(db.roller, "id", "rol", users.RolId);

            Session["UsersAd"] = users.Ad;
            Session["UsersSoyAd"] = users.Soyad;
            Session["UsersMail"] = users.Eposta;
            Session["UsersWebSite"] = users.WebSitesi;
            Session["UsersPhone"] = users.Telefon;
            Session["UsersIl"] = users.iller.sehiradi;
            Session["UsersCinsiyey"] = users.cinsiyetler.cinsiyet;
            Session["UsersDTarihi"] = users.Dogumtarihi;
            Session["UsersUyruk"] = users.Uyruk;
            Session["UsersMedeniHali"] = users.medenihaller.medenihal;
            Session["UsersLinkedin"] = users.Linkedin;
            Session["UsersAskerlikDurumu"] = users.askerlikdurumlari.askerlikdurum;
            Session["UsersProgrami"] = users.programlar;
            Session["UsersOgretimTuru"] = users.ogrenimturleri.ogrenimtur;
            Session["UsersGirisYili"] = users.GirisYili;
            Session["UsersMevzunYili"] = users.MezunYili;
            Session["UsersDiplomaNotu"] = users.DiplomaNotu;
            Session["UsersCalismaDurumu"] = users.calismadurumlari.calismadurum;

            return View(users);
        }

        // GET: users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Convert.ToInt32(Session["UsersId"]) != 1)
            {
                return RedirectToAction("Index", "Home");
            }
            users users = db.users.Find(id);
            db.users.Remove(users);
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
