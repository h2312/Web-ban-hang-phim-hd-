using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieStore.Models
{
    public class GioHang
    {
        Model1 db = new Model1();
        public int MaPhim { get; set; }
        public string TenPhim { get; set; }
        public double DonGia { get; set; } 
        public int SoLuong { get; set; }
        public double ThanhTien {
            get { return SoLuong * DonGia; }
        }
        //ham tao cho gio hang 
        public GioHang(int idPhim)
        {
            MaPhim = idPhim;
            phim phim = db.phims.Single(n => n.idphim == MaPhim);
            TenPhim = phim.tenphim;
            DonGia = double.Parse(phim.gia.ToString());
            SoLuong = 1;
        }
    }
}