using System.ComponentModel.DataAnnotations;

namespace GoFly.BL.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
