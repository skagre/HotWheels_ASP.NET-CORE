using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Models
{
    public class TaiKhoan
    {
        [Key]
        public int ID_TaiKhoan { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
