using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroAPI.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        protected Address() { }

        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Rua não pode ser vazia.", nameof(street));
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Número não pode ser vazio.", nameof(number));
            if (string.IsNullOrWhiteSpace(neighborhood))
                throw new ArgumentException("Bairro não pode ser vazio.", nameof(neighborhood));
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Cidade não pode ser vazia.", nameof(city));
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("Estado não pode ser vazio.", nameof(state));
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("País não pode ser vazio.", nameof(country));
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("CEP não pode ser vazio.", nameof(zipCode));
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
        public override string ToString()
        {
            return $"{Street}, {Number}, {Neighborhood}, {City}, {State}, {Country}, {ZipCode}";
        }
    }
}
