using System.ComponentModel.DataAnnotations;
namespace Lab_06.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("^((?=.*[a-z])(?=.*[A-Z])(?=.*\\d)).+$", ErrorMessage = "Must contain an uppercase letter, a number, and a symbol")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
