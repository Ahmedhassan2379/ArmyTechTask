using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Invoice;

namespace ArmyTechTask.BLL.ViewModel.InvoiceDetails
{
   public class GetInvoiceDetailsViewModel
    {
        public long ID { get; set; }

        public string ItemName { get; set; }

        public double ItemCount { get; set; }

        public double ItemPrice { get; set; }

        public double Total { get; set; }

        public long InvoiceHeaderID { get; set; }
    }
}
