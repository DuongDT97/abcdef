using test2.Model;

namespace test2.Models
{
    public class Combofooduser
    {
        public IEnumerable<Food>? Foods { get; set; }
        public IEnumerable<Combos>? Combos { get; set; }
        public IEnumerable<User>? users { get; set; }
        public IEnumerable<GioHang>? gioHangs { get; set; }
    }
}
