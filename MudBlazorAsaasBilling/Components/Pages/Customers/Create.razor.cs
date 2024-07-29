using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorAsaasBilling.Extensions;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Customers;
using MudBlazorAsaasBilling.Services;

namespace MudBlazorAsaasBilling.Components.Pages.Customers
{
    public class CreateCustomerPage : ComponentBase
    {
        [Inject]
        private IAsaasService asaasService { get; set; } = null!;

        [Inject]
        public ICustomerRepository repository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public CustomerInputModel InputModel { get; set; } = new();

        public DateTime? DateOfBirth { get; set; } = DateTime.Today;

        public DateTime? MaxDate { get; set; } = DateTime.Today;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                var userId = await GetUserIdAsync();

                if (editContext.Model is CustomerInputModel model)
                {
                    var asaasCustomerId = await asaasService.CreateCustomerAsync(model);

                    var customer = new Customer
                    {
                        Name = model.Name,
                        UserId = userId,
                        IdAsaas = asaasCustomerId,
                        Document = model.Document.CharactersOnly(),
                        Phone = model.Phone.CharactersOnly(),
                        Email = model.Email,
                        DateOfBirth = DateOfBirth.Value
                    };

                    await repository.AddAsync(customer);
                    Snackbar.Add("Customer created successfully!", Severity.Success);
                    NavigationManager.NavigateTo("/customers");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        private async Task<string> GetUserIdAsync()
        {
            var user = (await AuthenticationState).User;
            var userId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userId;
        }
    }
}
