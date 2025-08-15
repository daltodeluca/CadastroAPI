using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário só pode ter no máximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(50, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{6,50}$", ErrorMessage = "A senha deve conter letras maiúsculas, minúsculas, números e símbolos.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public string Role { get; set; }
    }
}