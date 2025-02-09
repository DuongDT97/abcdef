using test2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test2.Model
{
    public class GioHang
    {
        [Key]
        public int GioHangId { get; set; } // ID của giỏ hàng
        [Required]
        public int KhachHangID { get; set; } // ID của khách hàng
        [Required]
        public int MonAnID { get; set; } // ID món ăn (Có thể NULL nếu là combo)       
        public DateTime NgayTao { get; set; } // Ngày tạo giỏ hàng
        public string? DaThanhToan { get; set; } // Trạng thái thanh toán
        public int soluong { get; set; } // Số lượng sản phẩm (tổng số sản phẩm trong giỏ)
        public decimal TongTien { get; set; } // Tổng tiền giỏ hàng
        public virtual User? KhachHang { get; set; }
        public virtual Food? Foods { get; set; }
        public virtual ICollection<Donhang>? Donhangs { get; set; }

        // Thuộc tính chứa danh sách chi tiết giỏ hà

    }
}
