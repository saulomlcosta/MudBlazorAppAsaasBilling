using MudBlazorAsaasBilling.Components.Pages.Billings;
using MudBlazorAsaasBilling.Components.Pages.Customers;

namespace MudBlazorAsaasBilling.Services
{
    public interface IAsaasService
    {
        Task<string> CreateCustomerAsync(CustomerInputModel model);
        Task<bool> UpdateCustomerAsync(CustomerInputModel model);
        Task<bool> DeleteCustomerAsync(string customerId);

        Task<string> CreateBillingAsync(BillingInputModel model, string idAsaas);

    }
}
