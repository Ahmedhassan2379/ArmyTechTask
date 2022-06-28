using System;
using System.Collections.Generic;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;

namespace ArmyTechTask.BLL.ViewModel.Invoice
{
   public class GetInvoiceViewModel
    {
        public long ID { get; set; }

        public string CustomerName { get; set; }

        public DateTime InvoiceDate { get; set; }

        public double Total { get; set; }

        public int BranchID { get; set; }

        public string BranchName { get; set; }

        public int? CashierID { get; set; }

        public string CashierName { get; set; }

        public virtual ICollection<GetInvoiceDetailsViewModel> InvoiceDetails { get; set; }
    }
}
