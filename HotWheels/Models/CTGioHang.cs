using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class CTGioHang
    {
        [Key]
        public int ID_CTGioHang { get; set; }

        public int SoLuong { get; set; }

        public string ID_GioHang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual GioHang GioHang { get; set; }
    }
}
