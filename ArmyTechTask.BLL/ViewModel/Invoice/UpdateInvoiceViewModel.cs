using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.BLL.ViewModel.Cashier;

namespace ArmyTechTask.BLL.ViewModel.Invoice
{
   public class UpdateInvoiceViewModel
    {
        [Required(ErrorMessage = "Invoice Header Id is Required")]
        public long ID { get; set; }

        [Required(ErrorMessage = "Customer Name Is Required")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Invoice Date Is Required")]
        [Display(Name = "Invoice Date")]
        [DataType(DataType.DateTime)]
        public DateTime Invoicedate { get; set; }

        [Required(ErrorMessage = "Branch Is Required")]
        [Display(Name = "Branch")]
        public int BranchID { get; set; }

        [Display(Name = "Cashier")]
        public int? CashierID { get; set; }

        public IEnumerable<SelectListItem> Branches { get; set; }
        public IEnumerable<SelectListItem> Cashiers { get; set; }
    }
}
