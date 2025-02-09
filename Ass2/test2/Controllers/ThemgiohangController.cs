using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System.Net;
using test2.Model;


namespace test2.Controllers
{
    public class ThemgiohangController : Controller
    {
        private readonly HttpClient _httpClient;

        public ThemgiohangController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7233/api/");
        }

        // Lấy toàn bộ giỏ hàng
        public async Task<IActionResult> Getallgh()
        {
            var gihanglis = new List<GioHang>();
            var response = await _httpClient.GetAsync("Giohangthem");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                gihanglis = JsonConvert.DeserializeObject<List<GioHang>>(content);
            }
            return View(gihanglis);
        }
        /*  [HttpGet("Create")]
          public async Task<IActionResult> Create(int KhachHangID, int monAnID, int Soluong)
          {
              var timfood = await _httpClient.GetAsync($"Food/{monAnID}");
              var timuser = await _httpClient.GetAsync($"User/{KhachHangID}");

              if (timfood.IsSuccessStatusCode && timuser.IsSuccessStatusCode)
              {
                  var foodContent = await timfood.Content.ReadAsStringAsync();
                  var food = JsonConvert.DeserializeObject<Food>(foodContent);

                  var userContent = await timuser.Content.ReadAsStringAsync();
                  var user = JsonConvert.DeserializeObject<User>(userContent);
                  var gop = new GioHang
                  {
                      Foods = food,
                      KhachHang = user,
                      soluong = Soluong

                  };

                  return View(gop);
              }
              return View();
          }*/
        [HttpGet]
        public IActionResult Create(int KhachHangID, int MonAnID)
        {
            var giphang = new GioHang
            {
                KhachHangID = KhachHangID,
                MonAnID = MonAnID,
             
            };
            return View(giphang);
        }
        [HttpPost]
       
        public async Task<IActionResult> Create( GioHang request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
/*
            request = new GioHang
            {
                MonAnID = idfoll,
                KhachHangID = Idkhachhang,
                soluong = soluong
            };*/

            var response = await _httpClient.PostAsJsonAsync("Giohangthem", request);

            if (response.IsSuccessStatusCode)
            {
                var gioHangResult = await response.Content.ReadFromJsonAsync<GioHang>();
                return RedirectToAction("Trangchu", "Foods");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();    
                return BadRequest(errorContent); 
            }

           
        }
        // Hàm xử lý lỗi phản hồi
     /*   private IActionResult HandleErrorResponse(HttpResponseMessage response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.MethodNotAllowed:
                    return BadRequest("Phương thức không được phép. Vui lòng kiểm tra lại yêu cầu của bạn.");
                case HttpStatusCode.BadRequest:
                    return BadRequest("Yêu cầu không hợp lệ. Vui lòng kiểm tra và thử lại.");
                default:
                    return BadRequest("Có lỗi xảy ra: " + response.StatusCode);
            }
        }*/
    }
}
