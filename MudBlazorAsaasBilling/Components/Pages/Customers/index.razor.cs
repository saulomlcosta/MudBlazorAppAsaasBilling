using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Customers;
using MudBlazorAsaasBilling.Services;

namespace MudBlazorAsaasBilling.Components.Pages.Customers
{
    public class IndexPage : ComponentBase
    {

        [Inject]
        private IAsaasService asaasService { get; set; } = null!;

        [Inject]
        public ICustomerRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;


        public List<Customer> Customers { get; set; } = new List<Customer>();

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task Delete(Customer customer)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Atention",
                    $"Are you sure you want to remove the customer {customer.Name}?",
                    yesText: "YES",
                    cancelText: "NO"
                );

                if (result is true)
                {
                    await asaasService.DeleteCustomerAsync(customer.IdAsaas.ToString());
                    await repository.DeleteByIdAsync(customer.Id);
                    Snackbar.Add($"Customer {customer.Name} removed sucessfully!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int id)
        {
            NavigationManager.NavigateTo($"/customers/{id}/update");
        }

        public void GoToBillings(int id)
        {
            NavigationManager.NavigateTo($"/billings/{id}");
        }

        protected override async Task OnInitializedAsync()
        {
            var userId = await GetUserIdAsync();

            Customers = await repository.GetAllAsync(userId);
        }

        private async Task<string> GetUserIdAsync()
        {
            var user = (await AuthenticationState).User;
            var userId = user.FindFirst(u => u.Type.Contains("nameidentifier"))?.Value;
            return userId;
        }

    }
}
