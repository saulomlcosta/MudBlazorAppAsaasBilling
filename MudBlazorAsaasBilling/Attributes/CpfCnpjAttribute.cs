using MudBlazorAsaasBilling.Utils;
using System.ComponentModel.DataAnnotations;

namespace MudBlazorAsaasBilling.Attributes
{
    public class CpfCnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("Document must be provided");
            }

            var document = value.ToString();

            if (!CpfCnpjUtils.IsValid(document))
            {
                return new ValidationResult("Invalid CPF or CNPJ number");
            }

            return ValidationResult.Success;
        }
    }
}
