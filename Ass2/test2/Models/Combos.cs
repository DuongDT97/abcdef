using test2.Models;
using System.ComponentModel.DataAnnotations;
using test2.Model;
namespace test2.Models
{
    public class Combos
    {
        [Key]
        public int ComboID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; }

        public string? LoaiCombo { get; set; } // "TuDo", "CoSan"
    }
}
