using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Billings;

namespace MudBlazorAsaasBilling.Components.Pages.Billings
{
    public class IndexPage : ComponentBase
    {
        [Parameter]
        public int CustomerId { get; set; }

        [Inject]
        public IBillingRepository repository { get; set; } = null!;

        [Inject]
        public IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;


        public List<Billing> Billings { get; set; } = new List<Billing>();

        public async Task Delete(Billing billing)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                    "Atention",
                    $"Are you sure you want to remove the billing?",
                    yesText: "YES",
                    cancelText: "NO"
                );

                if (result is true)
                {
                    await repository.DeleteByIdAsync(billing.Id);
                    Snackbar.Add($"Billing removed sucessfully!", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        public void GoToUpdate(int customerId, int billingId)
        {
            NavigationManager.NavigateTo($"/billings/{customerId}/{billingId}/update");
        }

     
        protected override async Task OnInitializedAsync()
        {
            Billings = await repository.GetAllAsync(CustomerId);
        }
    }
}
