using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication12.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        mezuntakipEntities db = new mezuntakipEntities();
        // GET: Security
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UsersToken"] = null;
            Session["UsersId"] = null;
            return RedirectToAction("Login");

        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.AskerlikDurumId = new SelectList(db.askerlikdurumlari, "id", "askerlikdurum");
            ViewBag.BolumId = new SelectList(db.bolumler, "id", "bolumadi");
            ViewBag.CalismaDurumId = new SelectList(db.calismadurumlari, "id", "calismadurum");
            ViewBag.CinsiyetId = new SelectList(db.cinsiyetler, "id", "cinsiyet");
            ViewBag.IllerId = new SelectList(db.iller, "id", "sehiradi");
            ViewBag.MedeniHalId = new SelectList(db.medenihaller, "id", "medenihal");
            ViewBag.OgretimTurId = new SelectList(db.ogrenimturleri, "id", "ogrenimtur");
            ViewBag.ProgramId = new SelectList(db.programlar, "id", "programadi");
            return View();

        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Ad,Soyad,Eposta,Sifre,Telefon,IllerId,CinsiyetId,RolId,Dogumtarihi,Uyruk,MedeniHalId,WebSitesi,Linkedin,AskerlikDurumId,ProgramId,OgretimTurId,GirisYili,MezunYili,DiplomaNotu,CalismaDurumId,BolumId")] users users)
        {
            if (ModelState.IsValid)
            {
                users.RolId = 2;
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Login");
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

        [HttpPost]
        public ActionResult Login(users user)
        {
            var Kullanici = db.users.FirstOrDefault(x => x.Ad == user.Ad && x.Sifre == user.Sifre);
            if (Kullanici != null)
            {
                Session["UsersAd"] = Kullanici.Ad;
                Session["UsersSoyAd"] = Kullanici.Soyad;
                Session["UsersMail"] = Kullanici.Eposta;
                Session["UsersWebSite"] = Kullanici.WebSitesi;
                Session["UsersPhone"] = Kullanici.Telefon;
                Session["UsersIl"] = Kullanici.iller.sehiradi;
                Session["UsersCinsiyey"] = Kullanici.cinsiyetler.cinsiyet;
                Session["UsersDTarihi"] = Kullanici.Dogumtarihi;
                Session["UsersUyruk"] = Kullanici.Uyruk;
                Session["UsersMedeniHali"] = Kullanici.medenihaller.medenihal;
                Session["UsersLinkedin"] = Kullanici.Linkedin;
                Session["UsersAskerlikDurumu"] = Kullanici.askerlikdurumlari.askerlikdurum;
                Session["UsersProgrami"] = Kullanici.programlar.programadi;
                Session["UsersOgretimTuru"] = Kullanici.ogrenimturleri.ogrenimtur;
                Session["UsersGirisYili"] = Kullanici.GirisYili;
                Session["UsersMevzunYili"] = Kullanici.MezunYili;
                Session["UsersDiplomaNotu"] = Kullanici.DiplomaNotu;
                Session["UsersCalismaDurumu"] = Kullanici.calismadurumlari.calismadurum;

                Session["UsersId"] = Kullanici.RolId;
                Session["UserId"] = Kullanici.id;
                FormsAuthentication.SetAuthCookie(user.Ad, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }
    }
}