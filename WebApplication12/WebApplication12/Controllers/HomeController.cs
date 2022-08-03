using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication12;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {

        private mezuntakipEntities db = new mezuntakipEntities();

        [Authorize]// GET: users
        public ActionResult Index()
        {
            //var users = db.users.Include(u => u.askerlikdurumlari).Include(u => u.bolumler).Include(u => u.calismadurumlari).Include(u => u.cinsiyetler).Include(u => u.iller).Include(u => u.medenihaller).Include(u => u.ogrenimturleri).Include(u => u.programlar).Include(u => u.roller);
            //var duyurular = db.duyurular.Include(d => d.users);
            //return PartialView(duyurular);
            return View();
        }

        [AllowAnonymous]
        public ActionResult UsersList()
        {
            var getDuyuru = db.duyurular.Where(x=>x.Yayinda==true).ToList();
            List<DuyurularModel> model = new List<DuyurularModel>();
            foreach (var item in getDuyuru)
            {
                DuyurularModel m = new DuyurularModel()
                {
                    Baslik = item.Baslik,
                    Icerik=item.Icerik
                };
                model.Add(m);

            }

            return PartialView(model);
        }
    }
}
