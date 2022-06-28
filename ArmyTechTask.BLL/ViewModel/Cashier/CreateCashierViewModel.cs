using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;

namespace ArmyTechTask.BLL.ViewModel.Cashier
{
   public class CreateCashierViewModel
    {
        [Required(ErrorMessage = "Cashier Name Is Required")]
        [Display(Name = "Name")]
        public string CashierName { get; set; }

        [Required(ErrorMessage = "Branch Is Required")]
        [Display(Name = "Branch")]
        public int BranchID { get; set; }

        public virtual ICollection<GetBranchViewModel> Branches { get; set; }

    }
}
