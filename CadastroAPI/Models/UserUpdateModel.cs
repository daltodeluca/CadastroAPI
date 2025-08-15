using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class UserUpdateModel
    {
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome de usuário só pode ter no máximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public string Role { get; set; }

        public string Password { get; set; }
    }
}