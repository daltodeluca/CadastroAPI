using System;

namespace CadastroAPI.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }

        public UserEntity(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public UserEntity(string name, string role)
        {
            Name = name;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }

        public void AlterarPassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
