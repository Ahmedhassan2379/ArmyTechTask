using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;

namespace ArmyTechTask.BLL.Services.InvoiceDetails
{
   public interface IInvoiceDetailService
    {
        ICollection<GetInvoiceDetailsViewModel> GetInvoiceDetails();

        GetInvoiceDetailsViewModel GetInvoiceDetailById(long invoiceDetailId);

        GetInvoiceDetailsViewModel Add(CreateInvoiceDetailsViewModel model);

        bool Update(UpdateInvoiceDetailsViewModel model);

        bool Delete(long invoiceDetailId);
    }
}
