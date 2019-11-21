using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class SanPham
    {
        [Key]
        public int ID_SanPham { get; set; }
        public string TenSanPham { get; set; }
        public decimal DonGia { get; set; }
        public string TyLe { get; set; }
        public string ChatLieu { get; set; }
        public string XuatXu { get; set; }
        public string MoTa { get; set; }
        public string Anh { get; set; }

        public int ID_ThuongHieu { get; set; }
        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
