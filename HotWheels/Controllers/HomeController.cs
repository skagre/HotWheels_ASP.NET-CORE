using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotWheels.Models;
using HotWheels.Inter;

namespace HotWheels.Controllers
{
    public class HomeController : Controller
    {
        private ISanPham _iSanPham;
        private IThuongHieu _iThuongHieu;
        private GioHang _gioHang;
        private IDonHang _iDonHang;

        public HomeController(ISanPham iSanPham, IThuongHieu iThuongHieu, GioHang gioHang, IDonHang iDonHang)
        {
            _iSanPham = iSanPham;
            _iThuongHieu = iThuongHieu;
            _gioHang = gioHang;
            _iDonHang = iDonHang;
        }
        public IActionResult Index()
        {
            SanPhamVM sp = new SanPhamVM();
            sp.sanpham = _iSanPham.LayTatCaSanPham();
            sp.thuonghieu = _iThuongHieu.LayTatCaThuongHieu();
            return View(sp);
        }
        [HttpPost]
        public IActionResult Index(string s)
        {
            ViewBag.search = s;
            SanPhamVM sp = new SanPhamVM();
            sp.sanpham = _iSanPham.TimKiemSanPham(s);
            sp.thuonghieu = _iThuongHieu.LayTatCaThuongHieu();
            return View(sp);
        }

        public IActionResult ctsanpham(int id)
        {
            var sp = _iSanPham.LaySanPhamTheoID(id);
            return View(sp);
        }

        public IActionResult giohang()
        {
            var items = _gioHang.LayChiTietGioHang();
            _gioHang.ChiTietGioHang = items;

            var x = new GioHangVM
            {
                GioHang = _gioHang,
                TongTienGioHang = _gioHang.TinhTongTienGioHang()
            };
            return View(x);
        }
        public IActionResult Them(int id)
        {
            var x = _iSanPham.LayTatCaSanPham().FirstOrDefault(p => p.ID_SanPham == id);
            if (x != null)
            {
                _gioHang.ThemSanPhamVaoGioHang(x, 1);
            }
            return RedirectToAction("giohang");
        }
        public IActionResult Xoa(int id)
        {
            var x = _iSanPham.LayTatCaSanPham().FirstOrDefault(p => p.ID_SanPham == id);
            if (x != null)
            {
                _gioHang.XoaSanPhamKhoiGioHang(x);
            }
            return RedirectToAction("giohang");
        }
        public IActionResult XoaGioHang(int id)
        {
            _gioHang.XoaGioHang();
            return RedirectToAction("giohang");
        }
        [HttpPost]
        public IActionResult thanhtoan(DonHang donhang)
        {
            var x = _gioHang.LayChiTietGioHang();
            _gioHang.ChiTietGioHang = x;

            _iDonHang.TaoDonHang(donhang);
            _gioHang.XoaGioHang();
            return View("thanhtoanthanhcong");
        }
        public IActionResult HienThiTheoThuongHieu(int id)
        {
            SanPhamVM x = new SanPhamVM();
            x.sanpham = _iSanPham.LayTatCaSanPhamTheoThuongHieu(id);
            x.thuonghieu = _iThuongHieu.LayTatCaThuongHieu();

            return View(x);
        }
    }
}
