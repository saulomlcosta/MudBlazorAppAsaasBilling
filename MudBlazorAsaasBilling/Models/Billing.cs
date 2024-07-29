namespace MudBlazorAsaasBilling.Models
{
    public class Billing : BaseModel
    {
        public string IdPaymentAsaas { get; set; } = null!;
        public string BillingType { get; set; } = null!;
        public float Value { get; set; } 
        public string Description { get; set; } = String.Empty;
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}
