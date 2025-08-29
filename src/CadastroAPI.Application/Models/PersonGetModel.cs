using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Application.Models
{
    public class PersonGetModel
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime BirthDate { get; }
        public string Phone { get; }
        public string Document { get; }
        public string Street { get; }
        public string Number { get; }
        public string Neighborhood { get; }
        public string City { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public DateTime CreatedAt { get; }

        public PersonGetModel(
            int id,
            string firstName,
            string lastName,
            string email,
            DateTime birthDate,
            string phone,
            string document,
            string street,
            string number,
            string neighborhood,
            string city,
            string state,
            string country,
            string zipCode,
            DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            Document = document;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            CreatedAt = createdAt;
        }
    }
}
