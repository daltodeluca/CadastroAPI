using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário só pode ter no máximo 50 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(50, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public string Role { get; set; }
    }
}