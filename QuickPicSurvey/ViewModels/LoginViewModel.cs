using System.ComponentModel.DataAnnotations;

namespace QuickPicSurvey.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
    }
}
