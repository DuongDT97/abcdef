using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
    public class Hoadon
    {
        [Key]
        public int HoaDonID { get; set; }
        [Required]
        public int DonHangID { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }

        // Điều hướng tới bảng DonHang
        public virtual Donhang? DonHang { get; set; }
    }
}
