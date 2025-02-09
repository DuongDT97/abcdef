using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.Model;
using test.Service;


namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiohangthemController : ControllerBase
    {
        private readonly Ifoodservice _foodservice;
        private readonly Iuserservice _userservice;
        private readonly Igiohangservice _igiohangservice;

        public GiohangthemController(Ifoodservice foodservice, Iuserservice userservice, Igiohangservice igiohangservice)
        {
            _foodservice = foodservice;
            _userservice = userservice;
            _igiohangservice = igiohangservice;
        }
        public class CreateGioHangRequest
        {
            public int MonAnID { get; set; }
            public int KhachHangID { get; set; }
            public int soluong { get; set; }
        }
        [HttpPost]
        public GioHang Tao(CreateGioHangRequest request) 
        {
            // Lấy thông tin món ăn và người dùng
            var food = _foodservice.GetFoodid(request.MonAnID);
            var user = _userservice.Tim(request.KhachHangID); 

            // Kiểm tra thông tin món ăn và người dùng
            if (food != null && user != null)
            {
                // Kiểm tra số lượng hợp lệ
                if (request.soluong > 0)
                {
                    var gio = new GioHang()
                    {
                        MonAnID = request.MonAnID,
                        KhachHangID = request.KhachHangID,
                        Soluong = request.soluong,
                        DaThanhToan = "Đang chờ thanh toán",
                        TongTien = request.soluong * food.Gia,
                    };

                    // Lưu vào giỏ hàng
                    var result = _igiohangservice.CreateGH(gio);
                    return result;
                }
                return null;
            }
            return null;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GioHang>> GetGioHang()
        {
            var listgi = _igiohangservice.Getgiohang();
            return Ok(listgi);
        }
    }
}
