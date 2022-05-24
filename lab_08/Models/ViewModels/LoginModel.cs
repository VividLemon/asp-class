using System.ComponentModel.DataAnnotations;
namespace Lab_06.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [UIHint("Username")]
        public string UserName { get; set; }
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }
        public string returnUrl { get; set; }
    }
}
