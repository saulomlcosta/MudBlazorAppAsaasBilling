using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace MudBlazorAsaasBilling.Models
{
    public class PaymentReceivedEvent
    {
        public string Id { get; set; }
        public string Event { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DateCreated { get; set; }

        public Payment Payment { get; set; }
    }

    public class Payment
    {
        public string Object { get; set; }
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string Customer { get; set; }
        public string? PaymentLink { get; set; }
        public decimal Value { get; set; }
        public decimal? NetValue { get; set; }
        public decimal? OriginalValue { get; set; }
        public decimal? InterestValue { get; set; }
        public string? Description { get; set; }
        public string BillingType { get; set; }
        public bool? CanBePaidAfterDueDate { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string? PixTransaction { get; set; }
        public string Status { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? OriginalDueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ClientPaymentDate { get; set; }
        public string? InvoiceUrl { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? ExternalReference { get; set; }
        public bool Deleted { get; set; }
        public bool Anticipated { get; set; }
        public bool Anticipable { get; set; }
        public DateTime? CreditDate { get; set; }
        public DateTime? EstimatedCreditDate { get; set; }
        public string? TransactionReceiptUrl { get; set; }
        public string? NossoNumero { get; set; }
        public string? BankSlipUrl { get; set; }
        public DateTime? LastInvoiceViewedDate { get; set; }
        public DateTime? LastBankSlipViewedDate { get; set; }
        public Discount Discount { get; set; }
        public Fine Fine { get; set; }
        public Interest Interest { get; set; }
        public bool PostalService { get; set; }
        public string? Custody { get; set; }
        public string? Refunds { get; set; }
    }

    public class Discount
    {
        public decimal Value { get; set; }
        public DateTime? LimitDate { get; set; }
        public int DueDateLimitDays { get; set; }
        public string Type { get; set; }
    }

    public class Fine
    {
        public decimal Value { get; set; }
        public string Type { get; set; }
    }

    public class Interest
    {
        public decimal Value { get; set; }
        public string Type { get; set; }
    }

    public class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        private const string DateFormat = "yyyy-MM-dd HH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), DateFormat, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat));
        }
    }
}
