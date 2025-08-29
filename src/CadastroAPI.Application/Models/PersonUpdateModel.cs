using CadastroAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroAPI.Application.Models
{
    public class PersonUpdateModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O sobrenome deve ter no máximo 100 caracteres.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        [StringLength(150, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone informado não é válido.")]
        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "O documento é obrigatório.")]
        [StringLength(20, ErrorMessage = "O documento deve ter no máximo 20 caracteres.")]
        public string Document { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo de documento é obrigatório.")]
        public EDocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "A rua é obrigatória.")]
        [StringLength(100, ErrorMessage = "A rua deve ter no máximo 100 caracteres.")]
        public string Street { get; set; } = string.Empty;

        [Required(ErrorMessage = "O número é obrigatório.")]
        [StringLength(10, ErrorMessage = "O número deve ter no máximo 10 caracteres.")]
        public string Number { get; set; } = string.Empty;

        [Required(ErrorMessage = "O bairro é obrigatório.")]
        [StringLength(50, ErrorMessage = "O bairro deve ter no máximo 50 caracteres.")]
        public string Neighborhood { get; set; } = string.Empty;

        [Required(ErrorMessage = "A cidade é obrigatória.")]
        [StringLength(50, ErrorMessage = "A cidade deve ter no máximo 50 caracteres.")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O estado é obrigatório.")]
        [StringLength(2, ErrorMessage = "O estado deve ter no máximo 2 caracteres.")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O país é obrigatório.")]
        [StringLength(50, ErrorMessage = "O país deve ter no máximo 50 caracteres.")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public string ZipCode { get; set; } = string.Empty;
    }
}
