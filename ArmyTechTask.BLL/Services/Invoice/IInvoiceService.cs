using System.Collections.Generic;
using ArmyTechTask.BLL.ViewModel.Invoice;

namespace ArmyTechTask.BLL.Services.Invoice
{
   public interface IInvoiceService
    {
        ICollection<GetInvoiceViewModel> GetInvoices();

        GetInvoiceViewModel GetInvoiceById(long invoiceHeaderId);

        GetInvoiceViewModel Add(CreateInvoiceViewModel model);

        bool Update(UpdateInvoiceViewModel model);

        bool Delete(long invoiceHeaderId);
    }
}
