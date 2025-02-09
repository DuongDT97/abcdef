using System.ComponentModel.DataAnnotations;

namespace test.Model
{
    public class Combos
    {
        [Key]
        public int ComboID { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; }
        public string? LoaiCombo { get; set; } 
        public int? Monawnid { get; set; }
        public Food? Food { get; set; }
    }
}
