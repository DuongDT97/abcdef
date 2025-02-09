using test2 .Model;
using test2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models
{
    public class Food
    {
        [Key]
        public int MonAnID { get; set; }
        [Required]
        public string Ten { get; set; }

        public string? MoTa { get; set; }
        [Required]
        public decimal Gia { get; set; }
        public string? HinhAnh { get; set; }
        [Required]
        public string Loai { get; set; } // "Mon an" hoặc "Do uong"
        [Required]
        public int SoLuong { get; set; }

        public string? TinhTrang { get; set; } // "Co san", "Khong co san"
    }
}
