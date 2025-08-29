using CadastroAPI.Domain.Enums;
using CadastroAPI.Domain.ValueObjects;
using System;

namespace CadastroAPI.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public Username Username { get; private set; }
        public Password Password { get; private set; }
        public EUserRole Role { get; private set; }

        protected UserEntity() { }

        public UserEntity(Username username, Password password, EUserRole role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            Role = role;
        }

        public UserEntity(Username username, EUserRole role)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
            Role = role;
        }

        public void SetPassword(Password password)
        {
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
        public void UpdateUsername(Username username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }

        public void UpdateRole(EUserRole role)
        {
            Role = role;
        }
    }
}
