using System.ComponentModel.DataAnnotations;

namespace test2.Model
{
    public class Ngansach
    {
        [Key]
        public int NgansachID { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongChiPhi { get; set; }
        public decimal LoiNhuan { get; set; } // TongDoanhThu - TongChiPhi
    }
}
