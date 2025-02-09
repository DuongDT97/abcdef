using test2.Model;
using System.ComponentModel.DataAnnotations;

namespace test2.Models
{
    public class User
    {
        [Key]
        public int KhachHangID { get; set; }
        [Required]
        public string TenDangNhap { get; set; }
        [Required]
        public string MatKhauHash { get; set; }

        public string? VaiTro { get; set; }// "KhachHang", "NhanVien", "Admin"
        [Required]
        public string Ten { get; set; }
        [Required]
        public string Ho { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? TrangThai { get; set; } // "ON", "OFF"
        [MaxLength(11)]
        [Required]
        public string Phone { get; set; }
        public virtual Donhang? Donhang { get; set; }
        public virtual ICollection<GioHang>? GioHangs { get; set; }
        public virtual ICollection<Donhang>? Donhangs { get; set; }
    }
}

