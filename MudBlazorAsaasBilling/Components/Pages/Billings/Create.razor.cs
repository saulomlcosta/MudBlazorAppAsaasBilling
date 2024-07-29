using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Billings;
using MudBlazorAsaasBilling.Repositories.Customers;
using MudBlazorAsaasBilling.Services;

namespace MudBlazorAsaasBilling.Components.Pages.Billings
{
    public class BillingCreatePage : ComponentBase
    {
        [Parameter]
        public int CustomerId { get; set; }

        [Inject]
        private IAsaasService asaasService { get; set; } = null!;

        [Inject]
        public IBillingRepository repository { get; set; } = null!;

        [Inject]
        public ICustomerRepository customerRepository { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        public BillingInputModel InputModel { get; set; } = new();

        public DateTime? DueDate { get; set; } = DateTime.Today;
        public DateTime? MinDate { get; set; } = DateTime.Today;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationState { get; set; }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is BillingInputModel model)
                {
                    var customer = await customerRepository.GetByIdAsync(CustomerId);
                    var idPaymentAsaas = await asaasService.CreateBillingAsync(model, customer.IdAsaas);
                    var billing = new Billing
                    {
                        IdPaymentAsaas = idPaymentAsaas,
                        CustomerId = CustomerId,
                        BillingType = model.BillingType,
                        Value = model.Value,
                        Description = model.Description,
                        DueDate = model.DueDate,
                        IsPaid = false
                    };                

                    await repository.AddAsync(billing);
                    Snackbar.Add("Billing created successfully!", Severity.Success);
                    NavigationManager.NavigateTo($"/billings/{CustomerId}");
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }
    }
}
