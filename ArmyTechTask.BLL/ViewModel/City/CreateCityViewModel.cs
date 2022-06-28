using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.BLL.ViewModel.City
{
   public class CreateCityViewModel
    {
        [Required(ErrorMessage = "City Name Is Required")]
        [Display(Name = "Name Of City")]
        public string CityName { get; set; }
    }
}
