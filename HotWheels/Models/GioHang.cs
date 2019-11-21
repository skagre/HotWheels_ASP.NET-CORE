using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class GioHang
    {
        private DB _context;
        private GioHang(DB context)
        {
            _context = context;
        }
        [Key]
        public string ID_GioHang { get; set; }
        public List<CTGioHang> ChiTietGioHang { get; set; }
        
        public static GioHang LayGioHang(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DB>();
            string id = session.GetString("id") ?? Guid.NewGuid().ToString();

            session.SetString("id", id);

            return new GioHang(context) { ID_GioHang = id };
        }

        public void ThemSanPhamVaoGioHang(SanPham sp, int sl)
        {
            var ct =
                    _context.CTGioHangDb.SingleOrDefault(
                        s => s.SanPham.ID_SanPham == sp.ID_SanPham && s.ID_GioHang == ID_GioHang);

            if (ct == null)
            {
                ct = new CTGioHang
                {
                    ID_GioHang = ID_GioHang,
                    SanPham = sp,
                    SoLuong = 1
                };

                _context.CTGioHangDb.Add(ct);
            }
            else
            {
                ct.SoLuong++;
            }
            _context.SaveChanges();
        }
        public int XoaSanPhamKhoiGioHang(SanPham sp)
        {
            var ct =
                    _context.CTGioHangDb.SingleOrDefault(
                        s => s.SanPham.ID_SanPham == sp.ID_SanPham && s.ID_GioHang == ID_GioHang);

            var t = 0;

            if (ct != null)
            {
                if (ct.SoLuong > 1)
                {
                    ct.SoLuong--;
                    t = ct.SoLuong;
                }
                else
                {
                    _context.CTGioHangDb.Remove(ct);
                }
            }

            _context.SaveChanges();

            return t;
        }

        public List<CTGioHang> LayChiTietGioHang()
        {
            return ChiTietGioHang ??
                   (ChiTietGioHang =
                       _context.CTGioHangDb.Where(x => x.ID_GioHang == ID_GioHang)
                           .Include(s => s.SanPham)
                           .ToList());
        }

        public void XoaGioHang()
        {
            var giohang = _context
                .CTGioHangDb
                .Where(x => x.ID_GioHang == ID_GioHang);

            _context.CTGioHangDb.RemoveRange(giohang);

            _context.SaveChanges();
        }

        public decimal TinhTongTienGioHang()
        {
            var tong = _context.CTGioHangDb.Where(x => x.ID_GioHang == ID_GioHang)
                .Select(c => c.SanPham.DonGia * c.SoLuong).Sum();
            return tong;
        }
    }
}
