namespace CadastroAPI.Models
{
    public class UserGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}