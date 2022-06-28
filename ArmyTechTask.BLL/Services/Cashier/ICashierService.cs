using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Cashier;

namespace ArmyTechTask.BLL.Services.Cashier
{
    public interface ICashierService
    {
        ICollection<GetCashierViewModel> GetCashiers();
        ICollection<GetCashierViewModel> GetCashiersByBranchId(int branchId);

        GetCashierViewModel GetCashierById(int cashierId);

        GetCashierViewModel Add(CreateCashierViewModel model);

        bool Update(UpdateCashierViewModel model);

        bool Delete(int cashierId);
    }
}
