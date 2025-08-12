using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Entities
{
    public class PessoaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
    }
}
