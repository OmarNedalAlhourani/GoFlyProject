using GoFly.Models.SharedProp;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoFly.BL.Models.HomePage
{
    public class Menu : CommonProp
    {
        [Key]
        public int MenuId { get; set; }

        public string? MenuName { get; set; }

        public int? PerentId { get; set; }

        public string MenuUrl { get; set; }
        [NotMapped]

        List <Menu> MenuList { get; set;}
    }
}
