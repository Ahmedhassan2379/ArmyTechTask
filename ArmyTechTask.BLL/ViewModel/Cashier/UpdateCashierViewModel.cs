using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;

namespace ArmyTechTask.BLL.ViewModel.Cashier
{
   public class UpdateCashierViewModel
    {
        [Required(ErrorMessage = "Cashier Id Is Required")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string CashierName { get; set; }

        [Display(Name = "Branch")]
        public int BranchID { get; set; }

        public virtual ICollection<GetBranchViewModel> Branches { get; set; }
    }
}
