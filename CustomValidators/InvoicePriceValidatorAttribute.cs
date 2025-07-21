using System.ComponentModel.DataAnnotations;
using ECom_App.Models;
using System.Reflection;

namespace ECom_App.CustomValidators 
{
    public class InvoicePriceValidator : ValidationAttribute
    {
        public string DefaultErrorMessage { get; set; } = "InvoicePrice should be equal to the total price of the products (i.e.{0}).";

            protected override ValidationResult? IsValid(object? value, ValidationContext validationcontext)
            {
                if(value != null)
                {
                    PropertyInfo? OtherProperty = validationcontext.ObjectType.GetProperty(nameof(Order.Products));

                    if(OtherProperty!= null)
                    {
                        List<Product> products = (List<Product>)OtherProperty.GetValue(validationcontext.ObjectInstance);

                        if (products != null) 
                        {
                            double TotalPrice = 0;
                            foreach (Product product in products)
                            {
                                TotalPrice += product.Quantity * product.Price;
                            }

                            double? InvoicePrice = (double?)value;


                            if (TotalPrice != InvoicePrice) 
                            {
                                return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, TotalPrice), new string[] {nameof(validationcontext.MemberName)});
                            }
                            return ValidationResult.Success;
                        }
                        
                    }
                    
                }
                return new ValidationResult("Products list is null or empty.", new string[] { nameof(validationcontext.MemberName) });
        }
    }
}