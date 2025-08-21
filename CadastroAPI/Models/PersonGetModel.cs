using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Models
{
    public class PersonGetModel
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Phone { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public PersonGetModel(int id, string firstName, string lastName, string email, DateTime birthDate, string phone, DateTime createdAt)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Phone = phone;
            CreatedAt = createdAt;
        }
    }
}
