using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Inter
{
    public interface IThuongHieu
    {
        ThuongHieu LayThuongHieuTheoID(int id);
        IEnumerable<ThuongHieu> LayTatCaThuongHieu();
        ThuongHieu Them(ThuongHieu th);
        ThuongHieu Sua(ThuongHieu th, int id);
        ThuongHieu Xoa(int id);
    }
}
