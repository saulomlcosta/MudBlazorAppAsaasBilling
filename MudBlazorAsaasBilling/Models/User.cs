using MudBlazorAsaasBilling.Data;

namespace MudBlazorAsaasBilling.Models
{
    public class User : ApplicationUser
    {
        public string Name { get; set; } = null!;
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
    }
}
