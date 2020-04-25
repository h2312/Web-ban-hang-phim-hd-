using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieStore.Models;
namespace MovieStore.Controllers
{
    public class GioHangController : Controller
    {
        Model1 db = new Model1();
        // GET: GioHang
        #region GioHang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Neu gio hang chua ton tai thi tien hanh khoi tao list gio hang (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        //Them gio hang
        public ActionResult ThemGioHang(int MaPhim, string strURL)
        {
            phim phim = db.phims.SingleOrDefault(n => n.idphim == MaPhim);
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lay ra session gio hang 
            List<GioHang> lstGioHang = LayGioHang();
            //Kiem tra sach nay da ton tai trong session[giohang] chua
            GioHang sp = lstGioHang.Find(n => n.MaPhim == MaPhim);
            if (sp == null)
            {
                sp = new GioHang(MaPhim);
                //Add phim moi them vao list
                lstGioHang.Add(sp);
                return Redirect(strURL);
            }
            else
            {
                sp.SoLuong++;
                return Redirect(strURL);
            }
        }
        //Cap nhat gio hang
        public ActionResult CapNhatGioHang(int MaP, FormCollection f)
        {
            //ktr id phim
            phim phim = db.phims.SingleOrDefault(n => n.idphim == MaP);
            //Neu get sai masp thi se tra ve trang loi 404
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lay gio hang ra tu session 
            List<GioHang> lstGioHang = LayGioHang();
            //Ktr gio hang co ton tai trong session
            GioHang sp = lstGioHang.SingleOrDefault(n => n.MaPhim == MaP);
            //Neu ton tai thi chung ta cho sua so luong
            if (sp != null)
            {
                sp.SoLuong = int.Parse(f["txtSL"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //xoa gio hang
        public ActionResult XoaGioHang(int MaP)
        {
            //ktr id phim
            phim phim = db.phims.SingleOrDefault(n => n.idphim == MaP);
            //Neu get sai masp thi se tra ve trang loi 404
            if (phim == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lay gio hang ra tu session 
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sp = lstGioHang.SingleOrDefault(n => n.MaPhim == MaP);
            //Neu ton tai thi chung ta cho xoa
            if (sp != null)
            {
                lstGioHang.RemoveAll(n => n.MaPhim == sp.MaPhim);
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xay dung trang gio hang
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        //Tinh tong so luong 
        private int TongSL()
        {
            int TongSL = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongSL = lstGioHang.Sum(n => n.SoLuong);
            }
            return TongSL;
        }
        //Tinh tong thanh tien
        private double TongTien()
        {
            double TongTien = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                TongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return TongTien;
        }
        //Tao partial gio hang
        public ActionResult GioHangPartial()
        {
            if (TongSL() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSL = TongSL();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Xay dung 1 view cho nguoi dung chinh sua gio hang
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }
        #endregion
        #region DatHang
        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiem tra dang nhap
            if (Session["User"] == null && Session["KhachHang"] == null)
            {
                return RedirectToAction("Login", "User"); 
            }
            //Kiem tra gio hang
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //Them gio hang
            hoadon hd = new hoadon();
            khachhang kh = (khachhang)Session["KhachHang"];
            //khachhang kh = new khachhang();
            //db.khachhangs.Where(u => u.username.Equals(Session["User"]));
            
            List<GioHang> gh = LayGioHang();
            hd.makh = kh.makh;
            hd.ngaylap = DateTime.Now;
            hd.kieuthanhtoan = "chờ duyệt";
            db.hoadons.Add(hd);
            db.SaveChanges();
            //Them chi tiet don hang
            foreach (var item in gh)
            {
                chitiethoadon cthd = new chitiethoadon();
                cthd.mahd = hd.mahd;
                cthd.idphim = item.MaPhim;
                cthd.tenphim = item.TenPhim;
                cthd.soluong = item.SoLuong;
                cthd.gia = item.DonGia;
                cthd.thanhtien = item.ThanhTien;
                db.chitiethoadons.Add(cthd);
            }
            db.SaveChanges();
            return RedirectToAction("DHTC", "GioHang");
            
        }
        public ActionResult DHTC()
        {
            Session["GioHang"] = null;
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}