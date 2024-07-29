using Microsoft.EntityFrameworkCore;
using MudBlazorAsaasBilling.Data;
using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Repositories.Billings
{
    public class BillingRepository : IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Billing billing)
        {
            _context.Billings.Add(billing);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var billing = await GetByIdAsync(id);
            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Billing>> GetAllAsync(int customerId)
        {
            return await _context
                        .Billings
                        .Where(x => x.CustomerId == customerId)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Billing?> GetByIdAsync(int id)
        {
            return await _context
                            .Billings
                            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Billing?> GetByIdPaymentAsaasAsync(string id)
        {
            return await _context
                            .Billings
                            .SingleOrDefaultAsync(x => x.IdPaymentAsaas == id);
        }

        public async Task UpdateAsync(Billing billing)
        {
            _context.Update(billing);
            await _context.SaveChangesAsync();
        }
    }
}
