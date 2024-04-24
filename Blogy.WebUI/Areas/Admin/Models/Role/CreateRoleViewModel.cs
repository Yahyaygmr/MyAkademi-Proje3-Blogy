using System.ComponentModel.DataAnnotations;

namespace Blogy.WebUI.Areas.Admin.Models.Role
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
