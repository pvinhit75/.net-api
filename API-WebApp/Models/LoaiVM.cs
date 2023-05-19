using System.ComponentModel.DataAnnotations;

namespace API_WebApp.Models
{
    public class LoaiVM
    {
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
