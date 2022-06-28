using System.Collections.Generic;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.BLL.ViewModel.City;

namespace ArmyTechTask.BLL.ViewModel.Branch
{
   public class GetBranchViewModel
    {
        public int ID { get; set; }

        public string BranchName { get; set; }

        public int CityID { get; set; }

        public virtual GetCityViewModel City { get; set; }
    }
}
