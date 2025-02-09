using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test.Model
{
    public class Hoadon
    {
        [Key]
        public int HoaDonID { get; set; }
        public int? DonHangID { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }
        public virtual Donhang? DonHang { get; set; }
    }
}
