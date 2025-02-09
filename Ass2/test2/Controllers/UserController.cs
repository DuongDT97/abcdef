using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using test2.Model;
using test2.Models;
namespace test2.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        public UserController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7233/api/");
        }
        
        [HttpPost]
        public async Task<IActionResult> login(Loginguser loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync("User", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();

                // Lấy đối tượng "value" trước
                if (result.TryGetProperty("value", out JsonElement valueElement))
                {
                    // Tiếp theo, lấy "token" từ đối tượng "value"
                    if (valueElement.TryGetProperty("token", out JsonElement tokenElement))
                    {
                        var token = tokenElement.GetString();
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var jwtToken = tokenHandler.ReadJwtToken(token);
                        var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role")?.Value; // "Admin"
                        var id = jwtToken.Claims.FirstOrDefault(x => x.Type == "KhachHangID")?.Value;
                        var username = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value; // "a"
                        Response.Cookies.Append("access_token", token, new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            Expires = DateTimeOffset.UtcNow.AddHours(1)
                        });
                        TempData["TenDangNhap"] = username;
                        TempData["id"] = id;
                          // Chuyển hướng dựa trên vai trò
                        return role switch
                        {
                            "admin" => RedirectToAction("Admin"),
                            "User" => RedirectToAction("Trangchu", "Foods"),
                            _ => RedirectToAction("Trangchu", "Foods"),
                        };
                    }
                }
            }
            return RedirectToAction("Trangchu", "Foods");
        }
        [HttpGet]
        public IActionResult Singin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Singin(User user)
        {
           
            // Gửi yêu cầu đăng ký với thông tin người dùng
            var nuser = await _httpClient.PostAsJsonAsync("User/Singin1", user);
            if (nuser.IsSuccessStatusCode)
            {
                var dn = new
                {
                    tenDangNhap = user.TenDangNhap,
                    matKhau = user.MatKhauHash,
                };
                // Gửi yêu cầu đăng nhập
                var log = await _httpClient.PostAsJsonAsync("User", dn);
                if (log.IsSuccessStatusCode)
                {
                    var result = await log.Content.ReadFromJsonAsync<JsonElement>();
                    // Lấy đối tượng "value" trước
                    if (result.TryGetProperty("value", out JsonElement valueElement))
                    {
                        // Tiếp theo, lấy "token" từ đối tượng "value"
                        if (valueElement.TryGetProperty("token", out JsonElement tokenElement))
                        {
                            var token = tokenElement.GetString();
                            var tokenHandler = new JwtSecurityTokenHandler();
                            var jwtToken = tokenHandler.ReadJwtToken(token);

                            var username = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name")?.Value; // "a"
                            Response.Cookies.Append("access_token", token, new CookieOptions
                            {
                                HttpOnly = true,
                                Secure = true,
                                Expires = DateTimeOffset.UtcNow.AddHours(1)
                            });
                            TempData["TenDangNhap"] = username;
                            // Chuyển hướng dựa trên vai trò
                            return RedirectToAction("Trangchu", "Foods");
                        }
                    }
                    TempData["er"] = "Lỗi đăng ký!";
                    return View(user);
                }
                // Nếu yêu cầu đăng nhập không thành công
                TempData["er"] = "Đăng nhập không thành công!  ";
                return View(user); // Trả về view với đối tượng user để hiển thị thông tin người dùng đã nhập
            }
            // Nếu yêu cầu đăng ký không thành công
            TempData["er"] = "Lỗi đăng ký!Tên đăng nhập đã tồn tại";
            return View(user); // Trả về view với đối tượng user để hiển thị thông tin
        }
        [HttpGet]
        public IActionResult Themnhanvie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Themnhanvien(User user)
        {
            var newnv = new User
            {
                Ten = user.Ten,
                Ho = user.Ho,
                TenDangNhap = user.TenDangNhap,
                Email = user.Email,
                Phone = user.Phone,
                VaiTro = user.VaiTro,
                TrangThai = user.TrangThai
            };
            var nv =await _httpClient.PostAsJsonAsync("User/themnv", user);
            if (nv.IsSuccessStatusCode)
            {
                return View(nv);
            }
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Danhsachnhanvien(User user)
        {
            var nv = await _httpClient.GetAsync("User/RollNv");
            if (nv.IsSuccessStatusCode) 
            {
                return View(nv);
            
            }
            return View(new List<User>());
        }
        [HttpGet]
        public async Task<IActionResult> DanhsachUser(User user)
        {
            var nv = await _httpClient.GetAsync("User/RollUs");
            if (nv.IsSuccessStatusCode)
            {
                return View(nv);

            }
            return View(new List<User>());
        }
       
        [HttpPost]
        public async  Task<IActionResult> Dongbangtk(int id)
        {
            var user = await _httpClient.GetAsync("User/getuser");
            if (user != null) 
            {
                var db = await _httpClient.PutAsJsonAsync("User/userdb", user);
                if (db.IsSuccessStatusCode) 
                {
                    return RedirectToAction("DanhsachUser");
                }
            }
            return View(user);
        }
        public IActionResult Admin()
        {
            return View();
        }
}
}



