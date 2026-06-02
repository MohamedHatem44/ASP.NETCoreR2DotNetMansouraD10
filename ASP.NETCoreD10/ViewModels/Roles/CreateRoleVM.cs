using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreD10.ViewModels.Roles
{
    public class CreateRoleVM
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
