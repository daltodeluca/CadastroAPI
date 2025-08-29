using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Password
    {
        public byte[] Hash { get; private set; }
        public byte[] Salt { get; private set; }

        protected Password() { }

        public Password(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }
    }
}
