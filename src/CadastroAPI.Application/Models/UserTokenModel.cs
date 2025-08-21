using CadastroAPI.Domain.Enums;

namespace CadastroAPI.Application.Models
{
    public class UserTokenModel
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public UserRole Role { get; set; }
        public DateTime Expiration { get; set; }
    }
}
