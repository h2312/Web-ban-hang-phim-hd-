using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
namespace MovieStore.Controllers
{
    public class PhimController : Controller
    {
        // GET: Phim
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Chitiet(int pid)
        {
            Model1 db = new Model1();
            phim ph = db.phims.Where(p => p.idphim == pid).SingleOrDefault();
            if (ph == null)
            {
                //tra ve trang bao loi
                Response.StatusCode = 404;
                return null;
            }
            return View(ph);
        }
        [ChildActionOnly]
        public ActionResult dsDanhMuc()
        {
            Model1 db = new Model1();
            List<danhmucphim> dsdm = db.danhmucphims.ToList();
            return PartialView(dsdm);
        }
        public ActionResult dsPhim(int dmID)
        {
            Model1 db = new Model1();
            List<phim> pList = db.phims.Where(dm => dm.madm == dmID).ToList();
            if (pList.Count == 0)
            {
                ViewBag.Phim = "Khong co phim nao thuoc chu de nay !";
            }
            ViewBag.TenDM = Request.QueryString["dmTen"].ToString();
            return View(pList);
        }
        //[ChildActionOnly]
        public ActionResult dsPhimBomTan()
        {
            Model1 db = new Model1();
            List<phim> pbt = db.phims.Where(n => n.phimbomtan == 1).OrderBy(n => n.idphim).Take(4).ToList();
            return PartialView(pbt);
        }

    }
}