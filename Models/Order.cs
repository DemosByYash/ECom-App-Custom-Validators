using System.ComponentModel.DataAnnotations;
using ECom_App.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ECom_App.Models
{
    public class Order
    {

        [BindNever]
        [Display(Name = "Order ID")]
        public int? OrderNo { get; set; }


        [DateTimeValidation]
        [Required(ErrorMessage = "Not Null.")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Not Null.")]
        [Range(1, double.MaxValue, ErrorMessage = "Total Price should be greater than 0.")]
        [Display(Name = "Total Price")]
        [InvoicePriceValidator]
        public double InvoicePrice { get; set; }


        [ProductsValidtor]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
