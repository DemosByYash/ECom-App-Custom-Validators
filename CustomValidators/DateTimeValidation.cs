using System.ComponentModel.DataAnnotations;
using ECom_App.Models;
using System.Reflection;

namespace ECom_App.CustomValidators
{
    public class DateTimeValidation: ValidationAttribute
    {
        string? DefaultErrorMessage { get; set; } = "OrderDate should be less than or equal to 2000-01-01.";


        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime InitialDate = DateTime.Parse("2000-01-01");

            if (value != null)
            {
                DateTime? orderDate = (DateTime?)value;
                DateTime DateToday = DateTime.Now;
                if (orderDate<InitialDate ||  orderDate >=  DateToday)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage), new string[] { nameof(validationContext.MemberName) });
                }
                return ValidationResult.Success;
            }

            return new ValidationResult("Plz provide an OrderDate", new string[] { nameof(validationContext.MemberName) });
        }
    }
}
