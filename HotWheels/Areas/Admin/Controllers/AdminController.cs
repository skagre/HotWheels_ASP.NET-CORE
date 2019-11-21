using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotWheels.Inter;
using HotWheels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotWheels.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private ISanPham _iSanPham;
        private IThuongHieu _iThuongHieu;
        private IDonHang _iDonHang;
        private ITaiKhoan _iTaiKhoan;
        public AdminController(ISanPham iSanPham, IThuongHieu iThuongHieu, IDonHang iDonHang, ITaiKhoan iTaiKhoan)
        {
            _iSanPham = iSanPham;
            _iThuongHieu = iThuongHieu;
            _iDonHang = iDonHang;
            _iTaiKhoan = iTaiKhoan;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("")]
        [Route("Index")]
        [HttpPost]
        public IActionResult Index(TaiKhoan taikhoan)
        {
            var tk = _iTaiKhoan.Login(taikhoan);
            if (tk != null)
            {
                return RedirectToAction("SanPham");
            }
            else
            {
                ViewBag.loidangnhap = "Sai tài khoản hoặc mật khẩu.";
            }
            return View();
        }
        [Route("DangXuat")]
        public IActionResult DangXuat()
        {
            return RedirectToAction("Login");
        }
        [Route("SanPham")]
        public IActionResult SanPham()
        {
            return View(_iSanPham.LayTatCaSanPham());
        }
        [Route("ThemSanPham")]
        public IActionResult ThemSanPham()
        {
            ViewBag.thuonghieu = _iThuongHieu.LayTatCaThuongHieu();
            return View();
        }
        [Route("ThemSanPham")]
        [HttpPost]
        public IActionResult ThemSanPham(SanPham sp, IFormFile Anh)
        {
            _iSanPham.Them(sp, Anh);
            return RedirectToAction("SanPham");
        }
        [Route("ChiTietSanPham/{id}")]
        public IActionResult ChiTietSanPham(int id)
        {
            return View(_iSanPham.LaySanPhamTheoID(id));
        }
        [Route("SuaSanPham/{id}")]
        public IActionResult SuaSanPham(int id)
        {
            ViewBag.thuonghieu = _iThuongHieu.LayTatCaThuongHieu();
            return View(_iSanPham.LaySanPhamTheoID(id));
        }
        [Route("SuaSanPham/{id}")]
        [HttpPost]
        public IActionResult SuaSanPham(SanPham sp, int id, IFormFile Anh)
        {
            _iSanPham.Sua(sp, id, Anh);
            return RedirectToAction("SanPham");
        }
        [Route("XoaSanPham/{id}")]
        public IActionResult XoaSanPham(int id)
        {
            _iSanPham.Xoa(id);
            return RedirectToAction("SanPham");
        }
        [Route("ThuongHieu")]
        public IActionResult ThuongHieu()
        {
            return View(_iThuongHieu.LayTatCaThuongHieu());
        }
        [Route("ThemThuongHieu")]
        public IActionResult ThemThuongHieu()
        {
            return View();
        }
        [Route("ThemThuongHieu")]
        [HttpPost]
        public IActionResult ThemThuongHieu(ThuongHieu thuonghieu)
        {
            _iThuongHieu.Them(thuonghieu);
            return RedirectToAction("ThuongHieu");
        }
        [Route("SuaThuongHieu/{id}")]
        public IActionResult SuaThuongHieu(int id)
        {
            return View(_iThuongHieu.LayThuongHieuTheoID(id));
        }
        [Route("SuaThuongHieu/{id}")]
        [HttpPost]
        public IActionResult SuaThuongHieu(ThuongHieu thuonghieu, int id)
        {
            _iThuongHieu.Sua(thuonghieu, id);
            return RedirectToAction("ThuongHieu");
        }
        [Route("XoaThuongHieu/{id}")]
        public IActionResult XoaThuongHieu(int id)
        {
            _iThuongHieu.Xoa(id);
            return RedirectToAction("ThuongHieu");
        }
        [Route("DonHang")]
        public IActionResult DonHang()
        {
            return View(_iDonHang.LayTatCaDonHang());
        }
        [Route("ChiTietDonHang/{id}")]
        public IActionResult ChiTietDonHang(int id)
        {
            return View(_iDonHang.LayDonHangTheoID(id));
        }
    }
}