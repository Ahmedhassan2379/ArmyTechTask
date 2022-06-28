using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.City;
using ArmyTechTask.DAL.Database;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.City
{
   public class CityService:ICityService
    {
        private readonly ArmyTechTaskDbContext _context;

        public CityService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        public ICollection<GetCityViewModel> GetCities()
        {
            var cities = _context.Cities.ToList();

            return Mapper.Map<ICollection<GetCityViewModel>>(cities);
        }

        public GetCityViewModel GetCityById(int cityId)
        {
            var city = _context.Cities.Find(cityId);

            return Mapper.Map<GetCityViewModel>(city);
        }

        public GetCityViewModel Add(CreateCityViewModel model)
        {
            var city = Mapper.Map<DAL.Models.City>(model);

            if (city==null)
            {
                return null;
            }

            _context.Cities.Add(city);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetCityViewModel>(city) : null;
        }

        public bool Update(UpdateCityViewModel model)
        {

            var oldValue = _context.Cities.Find(model.ID);

            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;


            return _context.SaveChanges() > 0;
        }

        public bool Delete(int cityId)
        {
            var city = _context.Cities.Find(cityId);

            if (city == null)
            {
                return false;
            }
            _context.Cities.Remove(city);

            return _context.SaveChanges() > 0;
        }
    }
}
