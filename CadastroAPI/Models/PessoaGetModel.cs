using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class PessoaGetModel
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Telefone { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public PessoaGetModel(int id, string nome, string sobrenome, string email, DateTime dataNascimento, string telefone, DateTime dataCriacao)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            DataCriacao = dataCriacao;
        }
    }
}
