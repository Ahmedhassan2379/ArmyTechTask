using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.BLL.ViewModel.Cashier;

namespace ArmyTechTask.BLL.ViewModel.InvoiceHeader
{
   public class UpdateInvoiceHeaderViewModel
    {
        [Required(ErrorMessage = "Invoice Header Id is Required")]
        public long ID { get; set; }

        public string CustomerName { get; set; }

        public DateTime Invoicedate { get; set; }

        public int BranchID { get; set; }

        public virtual GetBranchViewModel Branch { get; set; }

        public int? CashierID { get; set; }
        public virtual GetCashierViewModel Cashier { get; set; }

    }
}
