using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class SanPhamVM
    {
        public IEnumerable<SanPham> sanpham { get; set; }

        public IEnumerable<ThuongHieu> thuonghieu { get; set; }
    }
}
