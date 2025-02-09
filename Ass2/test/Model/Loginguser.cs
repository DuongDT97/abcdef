using System.ComponentModel.DataAnnotations;

namespace test.Model
{
    public class Loginguser
    {

        [Required]
        public string TenDangNhap { get; set; }

        [Required]
        public string MatKhau { get; set; } // Có thể là mật khẩu chưa băm
        public string? VaiTro { get; set; }

    }
}
