using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Inter
{
    public interface ITaiKhoan
    {
        TaiKhoan Login(TaiKhoan tk);
    }
}
