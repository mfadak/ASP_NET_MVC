using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult OrnekSayfa()
        {
            return View();
        }
        public ActionResult DigerSayfa()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult MenuBolum()
        {
            Menu[] m = new Menu[] {
                new Menu() {
                    Id = 1,
                    Yazi = "Google",
                    Url = "https://www.google.com"
                },
                new Menu() {
                    Id = 2,
                    Yazi = "Hotmail",
                    Url = "https://www.hotmail.com"
                },
                new Menu() {
                    Id = 3,
                    Yazi = "Twitter",
                    Url = "https://www.twitter.com"
                }
            };
            var menuler = m.ToList<Menu>();
            return PartialView("MenuBolum", menuler);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
