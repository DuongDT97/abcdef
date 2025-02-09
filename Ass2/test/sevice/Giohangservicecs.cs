using test.Model;
using test.Service;

namespace test.Service
{
    public class Giohangservicecs : Igiohangservice
    {
        private readonly Dbcon _dbcon;
        public Giohangservicecs(Dbcon dbcon)
        {
            _dbcon = dbcon;

        }
        public GioHang CreateGH(GioHang gioHang)
        {

            var gioh = _dbcon.Add(gioHang);
            var tim = _dbcon.GioHangs.FirstOrDefault(h => h.MonAnID == gioHang.MonAnID);
            if (tim != null) 
            {
                
                gioHang.Soluong = tim.Soluong + gioHang.Soluong;
                _dbcon.SaveChanges();
                
            }
            _dbcon.SaveChanges();
            return gioHang;
        }
        public IEnumerable<GioHang> Getgiohang()
        {
            return _dbcon.GioHangs.ToList();

        }
        public void Delete(int id)
        {
            var gio = _dbcon.GioHangs.Find(id);
            if (gio != null)
            {
                var tim = _dbcon.Donhangs.FirstOrDefault(x =>x.Idgiohang == gio.GioHangId);
                tim.Idgiohang = null;
                _dbcon.GioHangs.Remove(gio);
                _dbcon.SaveChanges();
            }
        }
        public void Thanhtoan(int id)
        {
            var gio = _dbcon.GioHangs.Find(id);
            if (gio != null)
            {
                var gionetest = new GioHang
                {
                    DaThanhToan = "Đang được sử lý",
                };
                _dbcon.SaveChanges();
            }
        }

    }
}
