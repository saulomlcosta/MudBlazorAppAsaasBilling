using Microsoft.EntityFrameworkCore;
using MudBlazorAsaasBilling.Data;
using MudBlazorAsaasBilling.Models;

namespace MudBlazorAsaasBilling.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var customer = await GetByIdAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync(string userId)
        {
            return await _context
                        .Customers
                        .Where(x => x.UserId == userId)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            return await _context
                            .Customers
                            .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
