using HotWheels.Inter;
using HotWheels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotWheels.Repo
{
    public class RThuongHieu : IThuongHieu
    {
        private DB _context;

        public RThuongHieu(DB context)
        {
            _context = context;
        }

        public IEnumerable<ThuongHieu> LayTatCaThuongHieu()
        {
            return _context.ThuongHieuDb;
        }

        public ThuongHieu LayThuongHieuTheoID(int id)
        {
            return _context.ThuongHieuDb.Find(id);
        }

        public ThuongHieu Sua(ThuongHieu th, int id)
        {
            ThuongHieu t = _context.ThuongHieuDb.Find(id);
            if (t != null)
            {
                t.TenThuongHieu = th.TenThuongHieu;
                _context.SaveChanges();
            }
            return t;
        }

        public ThuongHieu Them(ThuongHieu th)
        {
            _context.ThuongHieuDb.Add(th);
            _context.SaveChanges();
            return th;
        }

        public ThuongHieu Xoa(int id)
        {
            ThuongHieu t = _context.ThuongHieuDb.Find(id);
            if (t != null)
            {
                _context.ThuongHieuDb.Remove(t);
                _context.SaveChanges();
            }
            return t;
        }
    }
}
