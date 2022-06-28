using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.City;

namespace ArmyTechTask.BLL.ViewModel.Branch
{
   public class CreateBranchViewModel
    {
        [Required(ErrorMessage = "Branch Name Is Required")]
        public string BranchName { get; set; }

        [Display(Name = " City ")]
        public int CityID { get; set; }

        public virtual GetCityViewModel City { get; set; }

    }
}
