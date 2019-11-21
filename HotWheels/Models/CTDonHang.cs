using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class CTDonHang
    {
        [Key]
        public int ID_CTDonHang { get; set; }
        public int ID_DonHang { get; set; }
        public int ID_SanPham { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        public virtual SanPham SanPham { get; set; }
        public virtual DonHang DonHang { get; set; }
    }
}
