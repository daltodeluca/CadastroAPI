using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class PersonCreateModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome só pode ter no máximo 50 caracteres.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O sobrenome só pode ter no máximo 50 caracteres.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não possui um formato válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone não possui um formato válido.")]
        public string Phone { get; set; }
    }
}
