using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using test2.Models;
using test2.Model;

namespace test2.Models
{
    public class Donhang
    {
        [Key]
        
        public int DonHangID { get; set; }

        public int? Idgiohang { get; set; }
  
     
        public int Idfood { get; set; }
        public DateTime Ngay { get; set; }
        public string? Trangthai { get; set; }
        public virtual GioHang? GioHangs { get; set; }
      
        public virtual Food? Food { get; set; }

    }
}
