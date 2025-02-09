using test.Model;

namespace test.Service
{
    public interface Igiohangservice
    {
        public GioHang CreateGH(GioHang gioHang);
        public IEnumerable<GioHang> Getgiohang();
        public void Delete(int id);
        public void Thanhtoan(int id);
    }
}
