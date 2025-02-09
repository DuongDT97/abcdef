using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace test.Model
{
    public class Food
    {
        [Key]
        public int MonAnID { get; set; }

        public string Ten { get; set; }
        public string? MoTa { get; set; }
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }
        public string? Loai { get; set; }
        public int SoLuong { get; set; }
        public string? TinhTrang { get; set; }

        // Nếu bạn muốn giữ quan hệ một-nhiều:
        [JsonIgnore]
        public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();
    }

}
