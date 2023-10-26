using System.ComponentModel.DataAnnotations;

namespace GoFly.BL.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required (ErrorMessage ="Please enter Email")]
        [MaxLength (40,ErrorMessage = "Max 40 char")]
        [EmailAddress (ErrorMessage ="Exampel: user@gmail.com")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [DataType (DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Miss Match")]

        public string? ConfirmPassword { get; set; }

        public string? Mobile { get; set; }



    }
}
