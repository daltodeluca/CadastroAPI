using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Email
    {
        public string EmailAddress { get; private set; }

        protected Email() { }

        public Email(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                throw new ArgumentException("Email não pode ser vazio.", nameof(emailAddress));
            if (!IsValid(emailAddress))
                throw new ArgumentException("Email inválido.", nameof(emailAddress));
            EmailAddress = emailAddress;
        }

        private bool IsValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public override string ToString()
        {
            return EmailAddress;
        }
    }
}
