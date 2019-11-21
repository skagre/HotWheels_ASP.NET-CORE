using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class DonHang
    {
        [Key]
        public int ID_DonHang { get; set; }

        public List<CTDonHang> CTDonHang { get; set; }

        public string HoVaTen { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string Email { get; set; }

        public decimal TongTien { get; set; }

        public DateTime NgayDat { get; set; }
    }
}
