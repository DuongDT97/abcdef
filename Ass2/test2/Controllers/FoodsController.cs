using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using test2.Models;

namespace test2.Controllers
{
    public class FoodsController : Controller
    {
        private readonly HttpClient _httpClient;

        public FoodsController(HttpClient httpClient)
        {

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7233/api/");
        }
        public async Task<IActionResult> Trangchu()
        {

            var foodlis = new List<Food>();
            var combolis = new List<Combos>();
            var repon = await _httpClient.GetAsync("Food");
            if (repon.IsSuccessStatusCode)
            {
                var conten = await repon.Content.ReadAsStringAsync();
                foodlis = JsonConvert.DeserializeObject<List<Food>>(conten);
            }
            var view = new Combofooduser
            {
                Foods = foodlis,
                Combos = combolis,
            };
            return View(view);
        }
        public async Task<IActionResult> Getall()
        {
            var repon = await _httpClient.GetAsync("Food");
            if (repon.IsSuccessStatusCode)
            {
                var conten = await repon.Content.ReadAsStringAsync();
                var foodlist = JsonConvert.DeserializeObject<List<Food>>(conten);
                return View(foodlist);
            }
            ModelState.AddModelError("", "Không thể lấy dữ liệu người dùng.");
            return View(new List<Food>()); // Trả danh sách rỗng
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Food food, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Đường dẫn để lưu hình ảnh
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imageFile.FileName);

                // Lưu file vào thư mục
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                // Nếu cần, bạn có thể gán đường dẫn hình ảnh vào thuộc tính trong đối tượng Food
                food.HinhAnh = "/img/" + imageFile.FileName; // Giả sử có thuộc tính ImagePath trong Food
            }
            var app = await _httpClient.PostAsJsonAsync("Food", food);
            if (app.IsSuccessStatusCode)
            {
                return RedirectToAction("Getall");
            }
            var errorContent = await app.Content.ReadAsStringAsync();
            ModelState.AddModelError(string.Empty, $"Có lỗi xảy ra khi lưu thực phẩm: {errorContent}");
            return View(food);
        }

        [HttpGet("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                // Lấy đối tượng Food từ API
                var response = await _httpClient.GetAsync($"Food/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Không tìm thấy đối tượng Food với ID đã cho.");
                    return View(); // Trả về view nếu không tìm thấy
                }
                var content = await response.Content.ReadAsStringAsync();
                var food = JsonConvert.DeserializeObject<Food>(content);
                return View(food);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi lấy thông tin: " + ex.Message);
                return View();
            }
        }
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> Update(int id, Food food, IFormFile imageFile, string existingImagePath)
        {
            try
            {
                // Kiểm tra nếu người dùng có tải lên ảnh mới không
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Đường dẫn để lưu hình ảnh
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", imageFile.FileName);
                    // Lưu file vào thư mục
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                    // Cập nhật đường dẫn hình ảnh mới
                    food.HinhAnh = "/img/" + imageFile.FileName;
                }
                else
                {
                    // Nếu không có hình ảnh mới, giữ nguyên hình ảnh hiện tại trong đối tượng Food
                    food.HinhAnh = existingImagePath; // Giữ nguyên đường dẫn hình ảnh hiện tại
                }
                // Kiểm tra tính hợp lệ của dữ liệu
                var response = await _httpClient.PutAsJsonAsync($"Food/{id}", food);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Getall");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError("", errorMessage);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật: " + ex.Message);
            }
            return View(food);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var repon = await _httpClient.GetAsync($"Food/{id}");
            if (repon.IsSuccessStatusCode)
            {
                var conten = await repon.Content.ReadAsStringAsync();
                var food = JsonConvert.DeserializeObject<Food>(conten);
                return View(food);
            }
            ModelState.AddModelError("", "Không thể lấy dữ liệu người dùng.");
            return View(null);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Deletefood(int id)
        {
            var deleta = await _httpClient.DeleteAsync($"Food/{id}");
            if (deleta.IsSuccessStatusCode)
            {
                return RedirectToAction("Getall");
            }

            return View();
        }

       


    }
}
