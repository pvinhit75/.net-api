using System.ComponentModel.DataAnnotations;

namespace API_WebApp.Models
{
    public class LoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
