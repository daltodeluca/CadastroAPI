using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Username
    {
        public string Name { get; private set; }
        public Username(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome de usuário não pode ser vazio.", nameof(name));
            if (name.Length < 3)
                throw new ArgumentException("Nome de usuário não poder ter menos que 3 caracteres.");
            if (name.Length > 20)
                throw new ArgumentException("Nome de usuário não pode ter mais que 20 caracteres.");

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
