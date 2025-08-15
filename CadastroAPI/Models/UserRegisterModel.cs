using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "O nome de usu�rio � obrigat�rio.")]
        [StringLength(50, ErrorMessage = "O nome de usu�rio s� pode ter no m�ximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A senha � obrigat�ria.")]
        [StringLength(50, ErrorMessage = "A senha deve ter entre 6 e 50 caracteres.", MinimumLength = 6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{6,50}$", ErrorMessage = "A senha deve conter letras mai�sculas, min�sculas, n�meros e s�mbolos.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "O cargo � obrigat�rio.")]
        public string Role { get; set; }
    }
}