using Microsoft.AspNetCore.Mvc;
using MudBlazorAsaasBilling.Models;
using MudBlazorAsaasBilling.Repositories.Billings;

namespace MudBlazorAsaasBilling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        private IBillingRepository _repository;

        public WebhookController(IBillingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment([FromBody] PaymentReceivedEvent payment)
        {
            if (payment == null)
            {
                return BadRequest();
            }

            var billing = await _repository.GetByIdPaymentAsaasAsync(payment.Payment.Id);

            if (billing == null)
            {
                return NotFound();
            }

            if (payment.Payment.PaymentDate != default(DateTime))
            {
                billing.IsPaid = true;
                await _repository.UpdateAsync(billing);
            }

            return Ok();
        }

    }
}
