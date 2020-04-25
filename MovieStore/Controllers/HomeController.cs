using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
namespace MovieStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Model1 db = new Model1(); 
            List<phim> pList = db.phims.Where(n=>n.phimbomtan==null).OrderBy(n=>n.idphim).Take(6).ToList();
            return View(pList);
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