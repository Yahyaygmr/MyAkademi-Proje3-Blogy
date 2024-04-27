using System.ComponentModel.DataAnnotations;

namespace Blogy.WebUI.Models
{
    public class CreateResgisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
