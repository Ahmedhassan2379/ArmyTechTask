using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmyTechTask.BLL.ViewModel.City
{
   public class UpdateCityViewModel
    {
        [Required(ErrorMessage = "City Id Is Required ")]
        public int ID { get; set; }
        [Display(Name = "Name Of City")]
        public string CityName { get; set; }
    }
}
