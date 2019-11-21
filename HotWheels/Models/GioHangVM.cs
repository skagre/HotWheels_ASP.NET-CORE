using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class GioHangVM
    {
        public GioHang GioHang { get; set; }
        public decimal TongTienGioHang { get; set; }
        public DonHang DonHang { get; set; }
    }
}
