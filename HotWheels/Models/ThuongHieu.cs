using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class ThuongHieu
    {
        [Key]
        public int ID_ThuongHieu { get; set; }
        public string TenThuongHieu { get; set; }
    }
}
