using HotWheels.Inter;
using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Repo
{
    public class RTaiKhoan : ITaiKhoan
    {
        private DB _context;
        public RTaiKhoan(DB context)
        {
            _context = context;
        }

        public TaiKhoan Login(TaiKhoan tk)
        {
            var taikhoan = _context.TaiKhoanDb.Where(t => t.Username == tk.Username && t.Password == tk.Password).FirstOrDefault();
            if (taikhoan != null)
            {
                return taikhoan;
            }
            return null;
        }
    }
}
