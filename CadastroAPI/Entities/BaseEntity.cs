namespace CadastroAPI.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
