using CadastroAPI.Domain.ValueObjects;

namespace CadastroAPI.Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Phone Phone { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }

        protected PersonEntity() { }

        public PersonEntity(
            Name name,
            Email email,
            DateTime birthDate,
            Phone phone,
            Document document,
            Address address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            BirthDate = birthDate;
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }

        public void Update(
            Name name,
            DateTime birthDate,
            Email email,
            Phone phone,
            Document document,
            Address address)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            BirthDate = birthDate;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Address = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
