using BanhNgotApi.Data;
using BanhNgotApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanhNgotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SanPhamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> GetAll()
        {
            return await _context.SanPhams.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> GetById(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm" });
            }

            return sanPham;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<SanPham>>> Search(string? keyword, string? loai)
        {
            var query = _context.SanPhams.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.TenBanh.Contains(keyword));
            }

            if (!string.IsNullOrEmpty(loai))
            {
                query = query.Where(x => x.LoaiBanh == loai);
            }

            return await query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<SanPham>> Create(SanPham sanPham)
        {
            _context.SanPhams.Add(sanPham);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Thêm sản phẩm thành công",
                data = sanPham
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SanPham sanPham)
        {
            var oldSanPham = await _context.SanPhams.FindAsync(id);

            if (oldSanPham == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm" });
            }

            oldSanPham.MaBanh = sanPham.MaBanh;
            oldSanPham.TenBanh = sanPham.TenBanh;
            oldSanPham.LoaiBanh = sanPham.LoaiBanh;
            oldSanPham.MoTa = sanPham.MoTa;
            oldSanPham.GiaBan = sanPham.GiaBan;
            oldSanPham.SoLuongTon = sanPham.SoLuongTon;
            oldSanPham.HinhAnh = sanPham.HinhAnh;
            oldSanPham.TrangThai = sanPham.TrangThai;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật sản phẩm thành công" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
            {
              return NotFound(new { message = "Không tìm thấy sản phẩm" });
            }

            _context.SanPhams.Remove(sanPham);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa sản phẩm thành công" });
        }
    }
