using System.ComponentModel.DataAnnotations;
using ECom_App.Models;


namespace ECom_App.CustomValidators
{
    public class ProductsValidtor: ValidationAttribute
    {
        string DefaultErrorMessage { get; set; } = "Products list should not be null or empty.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext) 
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;
                if (products.Count > 0)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(DefaultErrorMessage, new string[] {nameof(validationContext.MemberName)});
                }
            }
            else
                {
                    return new ValidationResult(DefaultErrorMessage, new string[] { nameof(validationContext.MemberName) });
                }
        }
    }
}
