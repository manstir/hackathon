using System.ComponentModel.DataAnnotations;

namespace Surrogat.Areas.Issuer.Models
{
    public class NewAccountDTO
    {
        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Alias { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }
    }
}