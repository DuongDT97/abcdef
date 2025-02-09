using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test.Model
{
    public class GioHang
    {
        [Key]
        public int GioHangId { get; set; }
        public int? KhachHangID { get; set; }
        public int? MonAnID { get; set; }

        public DateTime NgayTao { get; set; }
        public string? DaThanhToan { get; set; }
        public int Soluong { get; set; }
        public decimal? TongTien { get; set; }
        [ForeignKey("KhachHangID")]
        public virtual User? KhachHang { get; set; }
        [ForeignKey("MonAnID")]

        public virtual Food? Food { get; set; } // Nếu muốn có mối quan hệ một-nhiều với Food, có thể giữ thuộc tính này.
    }

}
