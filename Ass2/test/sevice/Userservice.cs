using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using test.Model;

namespace test.Service
{
    public class Userservice : Iuserservice
    {
        private readonly Dbcon _dbcon;
        public Userservice(Dbcon dbcon)
        {
            _dbcon = dbcon;
        }
        public IActionResult Login(Loginguser loginguser)
        {
            var user = _dbcon.Users.FirstOrDefault(u => u.TenDangNhap == loginguser.TenDangNhap && u.MatKhauHash == loginguser.MatKhau);

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("YourVeryStrongSecretKey12dsasadaaaaa3456!"); // Thay thế bằng một khóa bảo mật hơn!
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.TenDangNhap),
                        new Claim(ClaimTypes.Role,user.VaiTro),
                        new Claim("KhachHangID", user.KhachHangID.ToString())
                      
                        // Bạn có thể thêm nhiều claims hơn nếu cần
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new OkObjectResult(new { token = tokenString });
            }
            return new UnauthorizedResult(); // Trả về phản hồi 401 Unauthorized
        }

        public User Singin(User newuser)
        {

            _dbcon.Users.Add(newuser);
            _dbcon.SaveChanges();
            return newuser;

        }
        public User Checked(User user)
        {
            var tim = _dbcon.Users.FirstOrDefault(u => u.TenDangNhap == user.TenDangNhap);
            return tim;
        }
        public User Tim(int id)
        {
            var user = _dbcon.Users.FirstOrDefault(f => f.KhachHangID == id);
            return user;
        }
        public List<User> GetUsersByRole(string role)
        {
            // Kiểm tra xem vai trò có hợp lệ không
            if (string.IsNullOrEmpty(role))
            {
                return new List<User>(); // Trả về danh sách rỗng nếu vai trò không hợp lệ
            }
            // Lấy danh sách người dùng có vai trò tương ứng
            var users = _dbcon.Users.Where(f => f.VaiTro == role).ToList();
            return users; // Trả về danh sách người dùng
        }

        public User Xoa (User user)
        {
            if (user != null)
            {
                // Tìm người dùng trong cơ sở dữ liệu theo ID
                var existingUser = _dbcon.Users.Find(user.KhachHangID); // Giả sử UserId là thuộc tính xác định người dùng

                // Nếu người dùng tồn tại trong cơ sở dữ liệu
                if (existingUser != null)
                {
                    existingUser.TrangThai = "OFF"; // Cập nhật trạng thái người dùng
                    _dbcon.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                    return existingUser; // Trả về người dùng đã được cập nhật
                }
            }
            return null;
        }
       
    }
}
