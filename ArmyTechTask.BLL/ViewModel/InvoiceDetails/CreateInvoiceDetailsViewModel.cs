using System;
using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.BLL.ViewModel.InvoiceDetails
{
   public class CreateInvoiceDetailsViewModel
    {
        [Required(ErrorMessage = "Item Name Is Required")]
        [Display(Name = "Name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Item Count Is Required")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Invalid Item Count")]
        [Display(Name = "Quantity")]
        public double ItemCount { get; set; }

        [Required(ErrorMessage = "Item Price Is Required")]
        [Range(minimum: 1, maximum: double.MaxValue, ErrorMessage = "Invalid Item Price")]
        [Display(Name = "Price")]
        public double ItemPrice { get; set; }

        [Required(ErrorMessage = "Invoice Header Is Required")]
        public long InvoiceHeaderID { get; set; }
    }
}
