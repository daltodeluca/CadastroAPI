using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Entities
{
    public class PessoaEntity : BaseEntity
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório")]
        [StringLength(100, ErrorMessage = "O sobrenome não pode ter mais de 100 caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email deve ser um endereço de email válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A data de nascimento é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "A data deve ser válida (DD/MM/AAAA)")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "O telefone deve ser um número de telefone válido")]
        public string Telefone { get; set; }
    }
}
