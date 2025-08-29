using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Application.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário só pode ter no máximo 50 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(50, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}