using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;

namespace ArmyTechTask.BLL.ViewModel.Invoice
{
   public class CreateInvoiceViewModel
    {
        [Required(ErrorMessage = "Customer Name Is Required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Branch Is Required")]
        [Display(Name = "Branch")]
        public int BranchID { get; set; }

        [Display(Name = "Cashier")]
        public int? CashierID { get; set; }

        public ICollection<CreateInvoiceDetailsViewModel> InvoiceDetails { get; set; }

        public IEnumerable<SelectListItem> Branches { get; set; }
    }
}
