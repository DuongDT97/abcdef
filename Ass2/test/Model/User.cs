using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace test.Model
{
    public class User
    {
        [Key]
        public int KhachHangID { get; set; }

        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhauHash { get; set; }
        public string? VaiTro { get; set; }
        [Required]
        public string Ten { get; set; }
        [Required]
        public string Ho { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? TrangThai { get; set; }

        public string Phone { get; set; }

        // Navigation properties
        [JsonIgnore] 
        public virtual ICollection<Donhang>? Donhangs { get; set; }
        [JsonIgnore] // Không tuần tự hóa thuộc tính này
        public virtual ICollection<GioHang>? GioHangs { get; set; }
    }
}

