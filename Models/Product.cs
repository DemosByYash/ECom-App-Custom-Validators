using System.ComponentModel.DataAnnotations;

namespace ECom_App.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Not Null.")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Not Null.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Not Null.")]
        public int Quantity { get; set; }
    }
}
