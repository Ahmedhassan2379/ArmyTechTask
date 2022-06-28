using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;

namespace ArmyTechTask.BLL.Services.Branch
{
   public interface IBranchService
   {
       ICollection<GetBranchViewModel> GetBranches();

       GetBranchViewModel GetBranchById(int branchId);
      ICollection<GetBranchViewModel> GetBranchesForUpdateCashier(int cashierId);
        GetBranchViewModel Add(CreateBranchViewModel model);

        bool Update(UpdateBranchViewModel model);

       bool Delete(int branchId);

   }
}
