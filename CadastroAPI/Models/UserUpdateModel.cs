using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class UserUpdateModel
    {
        [Required(ErrorMessage = "O nome de usu�rio � obrigat�rio.")]
        [StringLength(50, ErrorMessage = "O nome de usu�rio s� pode ter no m�ximo 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O cargo � obrigat�rio.")]
        public string Role { get; set; }

        public string Password { get; set; }
    }
}