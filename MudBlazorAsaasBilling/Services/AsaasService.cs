namespace MudBlazorAsaasBilling.Services
{
    using System.Net.Http;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using MudBlazorAsaasBilling.Components.Pages.Billings;
    using MudBlazorAsaasBilling.Components.Pages.Customers;
    using MudBlazorAsaasBilling.Helper;
    using MudBlazorAsaasBilling.Models;

    public class AsaasService : IAsaasService
    {
        private readonly HttpHelper _httpHelper;

        public AsaasService(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task<string> CreateCustomerAsync(CustomerInputModel model)
        {
            var AsaasCustomerModel = new
            {
                name = model.Name,
                cpfCnpj = model.Document,
                email = model.Email,
                phone = model.Phone
            };

            var response = await _httpHelper.SendRequestAsync<AsaasResponse>(HttpMethod.Post, "customers", AsaasCustomerModel);
            return response?.Id;
        }
        
        public async Task<string> CreateBillingAsync(BillingInputModel model, string idAsaas)
        {
            var AsaasBillingModel = new
            {
                customer = idAsaas,
                billingType = model.BillingType,
                value = model.Value,
                dueDate = model.DueDate
            };

            var response = await _httpHelper.SendRequestAsync<AsaasResponse>(HttpMethod.Post, "payments", AsaasBillingModel);
            return response?.Id;
        }

        public async Task<bool> UpdateCustomerAsync(CustomerInputModel model)
        {
            var AsaasCustomerModel = new
            {
                name = model.Name,
                cpfCnpj = model.Document,
                email = model.Email,
                phone = model.Phone
            };

            var response = await _httpHelper.SendRequestAsync<object>(HttpMethod.Put, $"customers/{model.IdAsaas}", AsaasCustomerModel);
            return true;
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            await _httpHelper.SendRequestAsync<object>(HttpMethod.Delete, $"customers/{customerId}");
            return true;
        }

        public class AsaasResponse
        {
            [JsonPropertyName("id")]

            public string Id { get; set; }
        }
    }
}
