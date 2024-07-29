using MudBlazorAsaasBilling.Enums;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorAsaasBilling.Components.Pages.Billings
{
    public class BillingInputModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string? IdAsaas { get; set; }

        [Required(ErrorMessage = "BillingType must be provided")]
        public string BillingType { get; set; }

        [Required(ErrorMessage = "Value must be provided")]
        public float Value { get; set; }

        [MaxLength(250, ErrorMessage = "{0} must be at most {1} characters long")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DuoDate must be provided")]
        public DateTime DueDate { get; set; } = DateTime.Today;
   
    }
}
