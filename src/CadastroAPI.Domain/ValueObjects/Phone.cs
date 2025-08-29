using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Phone
    {
        public string Number { get; private set; }

        protected Phone() { }

        public Phone(string number) 
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Número de telefone não pode ser vazio.", nameof(number));
            
            number = number.Replace(" ", "")
                           .Replace("(", "")
                           .Replace(")", "")
                           .Replace("-", "");

            if (!Regex.IsMatch(number, @"^[0-9]{8,15}$"))
                throw new ArgumentException("Telefone inválido.");
              
            Number = number;
        }

        public override string ToString() => Number;
    }
}
