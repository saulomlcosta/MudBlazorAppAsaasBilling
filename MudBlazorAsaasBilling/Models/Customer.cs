using MudBlazorAsaasBilling.Data;

namespace MudBlazorAsaasBilling.Models
{
    public class Customer : BaseModel
    {
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;
        public string IdAsaas { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Document { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBirth { get; set; } 
        public ICollection<Billing> Billings { get; set; } = new List<Billing>();
    }
}
