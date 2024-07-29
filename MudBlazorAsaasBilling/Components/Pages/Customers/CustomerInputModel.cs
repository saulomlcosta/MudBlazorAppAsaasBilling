using MudBlazorAsaasBilling.Attributes;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorAsaasBilling.Components.Pages.Customers
{
    public class CustomerInputModel
    {
        public int Id { get; set; }

        public string? UserId { get; set; }

        public string? IdAsaas { get; set; }

        [Required(ErrorMessage = "Name must be provided")]
        [MaxLength(50, ErrorMessage = "{0} must be at most {1} characters long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Document must be provided")]
        [CpfCnpj(ErrorMessage = "Invalid CPF or CNPJ number")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Email must be provided")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        [MaxLength(50, ErrorMessage = "{0} must be at most {1} characters long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone must be provided")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date of birth must be provided")]
        public DateTime DateOfBirth { get; set; } = DateTime.Today;
    }
}
