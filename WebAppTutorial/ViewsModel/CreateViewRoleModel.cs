using System.ComponentModel.DataAnnotations;

namespace WebAppTutorial.ViewsModel
{
    public class CreateViewRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
