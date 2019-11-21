using HotWheels.Inter;
using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Repo
{
    public class RDonHang : IDonHang
    {
        private DB _context;
        private GioHang _GioHangDb;

        public RDonHang(DB context, GioHang GioHangDb)
        {
            _context = context;
            _GioHangDb = GioHangDb;
        }
        public DonHang LayDonHangTheoID(int id)
        {
            return _context.DonHangDb.Find(id);
        }

        public IEnumerable<DonHang> LayTatCaDonHang()
        {
            return _context.DonHangDb;
        }

        public void TaoDonHang(DonHang dh)
        {
            dh.NgayDat = DateTime.Now;

            dh.TongTien = _GioHangDb.TinhTongTienGioHang();

            _context.DonHangDb.Add(dh);

            var chitietgiohang = _GioHangDb.ChiTietGioHang;

            foreach (var c in chitietgiohang)
            {
                var chitietdonhang = new CTDonHang()
                {
                    SoLuong = c.SoLuong,
                    ID_SanPham = c.SanPham.ID_SanPham,
                    ID_DonHang = dh.ID_DonHang,
                    Gia = c.SanPham.DonGia
                };

                _context.CTDonHangDb.Add(chitietdonhang);
            }

            _context.SaveChanges();
        }
    }
}
