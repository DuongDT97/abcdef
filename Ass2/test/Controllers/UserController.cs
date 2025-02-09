using Microsoft.AspNetCore.Mvc;
using test.Model;
using test.Service;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Iuserservice _userservice;
        public UserController(Iuserservice userservice)
        {
            _userservice = userservice;
        }
        [HttpPost]
        public IActionResult longing([FromBody] Loginguser loginModel)
        {
            var user = _userservice.Login(loginModel);
            if (user == null)
            {
                return Unauthorized("Tên đăng nhập hoặc mật khẩu không chính xác.");
            }
            return Ok(user);
        }
        [HttpPost("Singin1")]
        public User Singin(User user)
        {
            var tim = _userservice.Checked(user);
            if (tim == null)
            {
                var nuser = new User
                {
                    Ho = user.Ho,
                    Ten = user.Ten,
                    TenDangNhap = user.TenDangNhap,
                    Email = user.Email,
                    Phone = user.Phone,
                    TrangThai = "ON",
                    VaiTro = "User",
                    MatKhauHash = user.MatKhauHash,

                };
                var app = _userservice.Singin(nuser);
                return nuser;
            }
            return null;
        }
        [HttpGet("{id}")]
        public ActionResult<User> getuser(int id)
        {
            var user = _userservice.Tim(id);
            if (user != null)
            {
                return user;
            }
            return NotFound();

        }
        [HttpPost("themnv")]
        public User Themnhanvien(User user)
        {
            var tim = _userservice.Checked(user);
            if (tim != null)
            {
                var taonv = new User
                {
                    Ten = user.Ten,
                    Ho = user.Ho,
                    TenDangNhap = user.TenDangNhap,
                    Email = null,
                    Phone = user.Phone,
                    TrangThai = user.TrangThai,
                    VaiTro = "NhanVien",
                    MatKhauHash = user.MatKhauHash
                };

                // Gọi phương thức Signin và kiểm tra kết quả
                var addnv = _userservice.Singin(taonv); // Chỉnh sửa đối tượng truyền vào nếu cần
                return addnv;
            }
            return null;
        }
        [HttpGet("RollUs")]
        protected List<User> GetUsersByRoleUser(string role)
        {
            return _userservice.GetUsersByRole("User"); 
        }
        [HttpGet("RollNv")]
        protected List<User> GetUsersByRoleNV(string role)
        {
            return _userservice.GetUsersByRole("Nhanvien"); 
        }
        [HttpPut("userdb")]
        public User Xoa(User user)
        {

            var deletedUser = _userservice.Xoa(user);
            // Trả về người dùng đã bị xóa (hoặc có thể là null nếu không tìm thấy)
            return deletedUser;
        }



    }
}

