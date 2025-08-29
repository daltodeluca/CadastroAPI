using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CadastroAPI.Domain.Enums;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Document
    {
        public string Number { get; }
        public EDocumentType Type { get; }

        public Document(string number, EDocumentType type)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Documento não pode ser vazio.");

            number = number.Replace(".", "").Replace("-", "").Replace(" ", "");

            if (type == EDocumentType.CPF && number.Length != 11)
                throw new ArgumentException("CPF deve conter 11 dígitos.");
            if (type == EDocumentType.CNPJ && number.Length != 14)
                throw new ArgumentException("CNPJ deve conter 14 dígitos.");

            Number = number;
            Type = type;
        }

        public override string ToString() => Number;
    }
}
