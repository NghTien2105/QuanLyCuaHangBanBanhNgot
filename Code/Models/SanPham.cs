namespace BanhNgotApi.Models
{
    public class SanPham
    {
        public int Id { get; set; }

        public string MaBanh { get; set; } = string.Empty;

        public string TenBanh { get; set; } = string.Empty;

        public string LoaiBanh { get; set; } = string.Empty;

        public string MoTa { get; set; } = string.Empty;

        public decimal GiaBan { get; set; }

        public int SoLuongTon { get; set; }

        public string HinhAnh { get; set; } = string.Empty;

        public string TrangThai { get; set; } = string.Empty;
    }
}
