using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Inter
{
    public interface IDonHang
    {
        IEnumerable<DonHang> LayTatCaDonHang();
        DonHang LayDonHangTheoID(int id);
        void TaoDonHang(DonHang dh);
    }
}
