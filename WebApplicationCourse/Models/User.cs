using System.ComponentModel.DataAnnotations;

namespace WebApplicationCourse.Models
{
    public class User
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Длина логина должна быть от 2 до 25 символов")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль повторно")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        public override string ToString()
        {
            return $"{Login} {Password}";
        }
    }
}
