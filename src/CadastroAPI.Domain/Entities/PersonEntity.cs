using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
    }
}
