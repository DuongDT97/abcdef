using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test.Model
{
    public class Donhang
    {
        [Key]
        public int DonHangID { get; set; }


        public DateTime Ngay { get; set; }
        public string? Trangthai { get; set; }

        // Navigation properties
        public int? Idgiohang { get; set; }
        public virtual GioHang? GioHang { get; set; }

        public int Idfood { get; set; }
        public virtual Food? Food { get; set; }
    }
}
