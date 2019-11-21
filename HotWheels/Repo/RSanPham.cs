using HotWheels.Inter;
using HotWheels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Repo
{
    public class RSanPham : ISanPham
    {
        private  DB _context;
        public RSanPham(DB context)
        {
            _context = context;
        }

        public SanPham LaySanPhamTheoID(int id)
        {
            return _context.SanPhamDb.Find(id);
        }

        public IEnumerable<SanPham> LayTatCaSanPham()
        {
            return _context.SanPhamDb;
        }

        public IEnumerable<SanPham> LayTatCaSanPhamTheoThuongHieu(int id)
        {
            return _context.SanPhamDb.Where(x => x.ID_ThuongHieu == id).Select(x => x);
        }

        public SanPham Sua(SanPham sp, int id, IFormFile photo)
        {
            SanPham s = _context.SanPhamDb.Find(id);
            if (s != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", s.Anh);

                s.TenSanPham = sp.TenSanPham;
                s.DonGia = sp.DonGia;
                s.TyLe = sp.TyLe;
                s.ChatLieu = sp.ChatLieu;
                s.XuatXu = sp.XuatXu;
                ThemAnh(sp, photo);
                s.Anh = sp.Anh;
                s.MoTa = sp.MoTa;

                _context.SaveChanges();

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            return s;
        }

        public SanPham Them(SanPham sp, IFormFile photo)
        {
            ThemAnh(sp, photo);

            _context.SanPhamDb.Add(sp);
            _context.SaveChanges();
            return sp;
        }

        public void ThemAnh(SanPham sp, IFormFile photo)
        {
            Random r = new Random();
            string random = r.Next(1, 9999999).ToString();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", random + photo.FileName);
            var stream = new FileStream(path, FileMode.Create);
            photo.CopyToAsync(stream).Wait();
            sp.Anh = random + photo.FileName;
            stream.Close();
        }

        public IEnumerable<SanPham> TimKiemSanPham(string search)
        {
            return _context.SanPhamDb.Where(x => x.TenSanPham.Contains(search)).Select(x => x);
        }

        public SanPham Xoa(int id)
        {
            SanPham s = _context.SanPhamDb.Find(id);
            if (s != null)
            {
                _context.SanPhamDb.Remove(s);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", s.Anh);
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                _context.SaveChanges();
            }
            return s;
        }
    }
}
