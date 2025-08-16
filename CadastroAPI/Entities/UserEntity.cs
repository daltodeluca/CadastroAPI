using CadastroAPI.Enums;
using System;

namespace CadastroAPI.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; }

        public UserEntity(string username, UserRole role)
        {
            Username = username;
            Role = role;
        }

        public void SetPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
