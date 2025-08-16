using CadastroAPI.Enums;

namespace CadastroAPI.Models
{
    public class UserGetModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}