using System.ComponentModel.DataAnnotations;

namespace GoFly.BL.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Please enter Email")]
        [MaxLength(40, ErrorMessage = "Max 40 char")]
        [EmailAddress(ErrorMessage = "Exampel: user@gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
