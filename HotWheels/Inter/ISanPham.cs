using HotWheels.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Inter
{
    public interface ISanPham
    {
        SanPham LaySanPhamTheoID(int id);
        IEnumerable<SanPham> LayTatCaSanPham();
        IEnumerable<SanPham> LayTatCaSanPhamTheoThuongHieu(int id);
        IEnumerable<SanPham> TimKiemSanPham(string search);
        void ThemAnh(SanPham sp, IFormFile photo);
        SanPham Them(SanPham sp, IFormFile photo);
        SanPham Sua(SanPham sp, int id, IFormFile photo);
        SanPham Xoa(int id);
    }
}
