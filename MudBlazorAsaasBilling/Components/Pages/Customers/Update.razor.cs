using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorAsaasBilling.Extensions;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Customers;
using MudBlazorAsaasBilling.Services;

namespace MudBlazorAsaasBilling.Components.Pages.Customers
{
    public class UpdateCustomerPage : ComponentBase
    {

        [Parameter]
        public int CustomerId { get; set; }

        [Inject]
        private IAsaasService asaasService { get; set; } = null!;

        [Inject]
        public ICustomerRepository repository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public CustomerInputModel InputModel { get; set; } = new();
        private Customer? CurrentCustomer { get; set; }
        public DateTime? DateOfBirth { get; set; } = DateTime.Today;
        public DateTime? MaxDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentCustomer = await repository.GetByIdAsync(CustomerId);

            if (CurrentCustomer is null)
                return;

            InputModel = new CustomerInputModel
            {
                IdAsaas = CurrentCustomer.IdAsaas,
                Name = CurrentCustomer.Name,
                Phone = CurrentCustomer.Phone,
                DateOfBirth = CurrentCustomer.DateOfBirth,
                Email = CurrentCustomer.Email,
                Document = CurrentCustomer.Document,
            };

            DateOfBirth = CurrentCustomer.DateOfBirth;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is CustomerInputModel model)
                {
                    await asaasService.UpdateCustomerAsync(model);

                    CurrentCustomer.Name = model.Name;
                    CurrentCustomer.Document = model.Document.CharactersOnly();
                    CurrentCustomer.Phone = model.Phone.CharactersOnly();
                    CurrentCustomer.Email = model.Email;
                    CurrentCustomer.DateOfBirth = DateOfBirth.Value;

                    await repository.UpdateAsync(CurrentCustomer);

                    Snackbar.Add($"Customer {CurrentCustomer.Name} updated sucessfully!", Severity.Success);
                    NavigationManager.NavigateTo("/customers");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
