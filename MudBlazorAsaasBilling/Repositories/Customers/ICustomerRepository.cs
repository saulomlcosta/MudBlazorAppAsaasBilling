using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer paciente);
        Task UpdateAsync(Customer paciente);
        Task<List<Customer>> GetAllAsync(string userId);
        Task DeleteByIdAsync(int id);
        Task<Customer?> GetByIdAsync(int id);
    }
}
