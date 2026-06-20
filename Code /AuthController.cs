using BanhNgotApi.Data;
using BanhNgotApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanhNgotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _context.NhanViens
                .FirstOrDefaultAsync(x =>
                    x.TaiKhoan == request.TaiKhoan &&
                    x.MatKhau == request.MatKhau);

            if (user == null)
            {
                return Unauthorized(new
                {
                    message = "Tên đăng nhập hoặc mật khẩu không đúng"
                });
            }

            return Ok(new
            {
                message = "Đăng nhập thành công",
                user = new
                {
                    user.Id,
                    user.MaNV,
                    user.HoTen,
                    user.ChucVu,
                    user.TaiKhoan
                }
            });
        }
    }
}
