using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        public DbSet<SanPham> SanPhamDb { get; set; }
        public DbSet<ThuongHieu> ThuongHieuDb { get; set; }
        public DbSet<TaiKhoan> TaiKhoanDb { get; set; }
        public DbSet<CTGioHang> CTGioHangDb { get; set; }
        public DbSet<DonHang> DonHangDb { get; set; }
        public DbSet<CTDonHang> CTDonHangDb { get; set; }
    }
}
