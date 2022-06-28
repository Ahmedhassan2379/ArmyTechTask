using ArmyTechTask.BLL.ViewModel.Branch;

namespace ArmyTechTask.BLL.ViewModel.Cashier
{
   public class GetCashierViewModel
    {
        public int ID { get; set; }

        public string CashierName { get; set; }

        public int BranchID { get; set; }

        public virtual GetBranchViewModel Branch { get; set; }
    }
}
