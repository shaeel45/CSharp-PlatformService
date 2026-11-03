using System.ComponentModel.DataAnnotations;

namespace PlatformServices.Models
{
    public class PlatformUpdateDto 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string Cost { get; set; }
    }
}