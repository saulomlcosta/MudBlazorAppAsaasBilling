using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Billings;

namespace MudBlazorAsaasBilling.Components.Pages.Billings
{
    public class UpdateBillingPage : ComponentBase
    {

        [Parameter]
        public int CustomerId { get; set; }   
        
        [Parameter]
        public int BillingId { get; set; }

        [Inject]
        public IBillingRepository repository { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public BillingInputModel InputModel { get; set; } = new();
        private Billing? CurrentBilling { get; set; }
        public DateTime? DueDate { get; set; } = DateTime.Today;
        public DateTime? MinDate { get; set; } = DateTime.Today;

        protected override async Task OnInitializedAsync()
        {
            CurrentBilling = await repository.GetByIdAsync(BillingId);

            if (CurrentBilling is null)
                return;

            InputModel = new BillingInputModel
            {
                Id = CurrentBilling.Id,
                BillingType = CurrentBilling.BillingType,
                Value = CurrentBilling.Value,
                Description = CurrentBilling.Description,
                DueDate = CurrentBilling.DueDate
            };

            DueDate = CurrentBilling.DueDate;
        }

        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is BillingInputModel model)
                {
                    CurrentBilling.BillingType = model.BillingType;
                    CurrentBilling.Value = model.Value;
                    CurrentBilling.Description = model.Description;
                    CurrentBilling.DueDate = DueDate.Value;

                    await repository.UpdateAsync(CurrentBilling);

                    Snackbar.Add($"Billing updated sucessfully!", Severity.Success);
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
