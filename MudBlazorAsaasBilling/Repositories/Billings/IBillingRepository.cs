using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Repositories.Billings
{
    public interface IBillingRepository
    {
        Task AddAsync(Billing billing);
        Task UpdateAsync(Billing billing);
        Task<List<Billing>> GetAllAsync(int customerId);
        Task DeleteByIdAsync(int id);
        Task<Billing?> GetByIdAsync(int id);
        Task<Billing?> GetByIdPaymentAsaasAsync(string id);
    }
}
