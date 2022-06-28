using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.InvoiceHeader;

namespace ArmyTechTask.BLL.Services.InvoiceHeader
{
   public interface IInvoiceHeaderService
    {
        ICollection<GetInvoiceHeaderViewModel> GetInvoiceHeaders();

        GetInvoiceHeaderViewModel GetInvoiceHeaderById(long invoiceHeaderId);

        GetInvoiceHeaderViewModel Add(CreateInvoiceHeaderViewModel model);

        bool Update(UpdateInvoiceHeaderViewModel model);

        bool Delete(long invoiceHeaderId);
    }
}
