using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;

namespace ArmyTechTask.BLL.ViewModel.InvoiceHeader
{
   public class CreateInvoiceHeaderViewModel
    {
        [Required(ErrorMessage = "Customer Name Is Required")]
        public string CustomerName { get; set; }

        public DateTime Invoicedate { get; set; }

        public int BranchID { get; set; }

        public virtual GetBranchViewModel Branch { get; set; }

        public int? CashierID { get; set; }
        public virtual GetCashierViewModel Cashier { get; set; }

        public virtual ICollection<GetInvoiceDetailsViewModel> InvoiceDetails { get; set; }
    }
}
