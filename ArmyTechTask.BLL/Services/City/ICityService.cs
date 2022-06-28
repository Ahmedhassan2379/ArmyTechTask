using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.City;

namespace ArmyTechTask.BLL.Services.City
{
   public interface ICityService
    {
        ICollection<GetCityViewModel> GetCities();

        GetCityViewModel GetCityById(int cityId);

        GetCityViewModel Add(CreateCityViewModel model);

        bool Update(UpdateCityViewModel model);

        bool Delete(int cityId);
    }
}
