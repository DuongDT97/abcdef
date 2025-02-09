using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Model;
using test.Service;


namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly Ifoodservice _ifoodservice;
        public FoodController(Ifoodservice ifoodservice)
        {
            _ifoodservice = ifoodservice;
        }
        [HttpGet]
        public List<Food> GetFoodList()
        {
            return _ifoodservice.GetFoodList();
        }
        [HttpPost]
        public  Food Create(Food food) 
        {
            var newFood = new Food
            {
                MonAnID = food.MonAnID,
                Ten = food.Ten,
                Gia = food.Gia,
                HinhAnh = food.HinhAnh,
                Loai = food.Loai,
                MoTa = food.MoTa,
                SoLuong = food.SoLuong,
                TinhTrang = food.SoLuong > 0 ? "Có sẵn" : "Không có sẵn" // Thiết lập TinhTrang ngay tại đây
            };

            // Gọi dịch vụ để thêm thực phẩm mới
            var foods = _ifoodservice.Addfood(newFood);

            return foods;
        }
        [HttpGet("{id}")]
        public ActionResult<Food> Getfoodid(int id)
        {
            var tim = _ifoodservice.GetFoodid(id);
            if(tim != null)
            {
                return tim;
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Food food)
        {
            if (id != food.MonAnID)
            {
                return BadRequest("ID không khớp hoặc thực phẩm không hợp lệ.");
            }

            var existingFood = _ifoodservice.GetFoodid(id);
            if (existingFood != null)
            {
                existingFood.MoTa = food.MoTa;
                existingFood.SoLuong = food.SoLuong;
                existingFood.Ten = food.Ten;
                existingFood.Gia = food.Gia;
                existingFood.HinhAnh = food.HinhAnh;
                existingFood.Loai = food.Loai;
                existingFood.TinhTrang = food.SoLuong > 0 ? "Có sẵn" : "Không có sẵn"; // Thiết lập TinhTrang ngay tại đây

                _ifoodservice.Updatefood(existingFood); // Cập nhật đối tượng hiện có
                return Ok(existingFood);
            }
            else
            {
                return NotFound("Thực phẩm không tồn tại.");
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            var food = _ifoodservice.GetFoodid(id);
            if(food!= null)
            {
                _ifoodservice.Delete(food.MonAnID);
            }
        }
    }
}
