using Gaz.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Gaz.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Email { get; set; }
        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        public User User { get; set; }
    }
}