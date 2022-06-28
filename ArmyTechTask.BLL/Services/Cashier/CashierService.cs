using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.DAL.Database;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.Cashier
{

    public class CashierService:ICashierService
    {
        private readonly ArmyTechTaskDbContext _context;

        public CashierService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        


        public ICollection<GetCashierViewModel> GetCashiers()
        {
            var cashiers = _context.Cashiers.ToList();

            return Mapper.Map<ICollection<GetCashierViewModel>>(cashiers);
        }

        public ICollection<GetCashierViewModel> GetCashiersByBranchId(int branchId)
        {
            var cashiers = _context.Cashiers.Where(c => c.BranchID == branchId).ToList();

            return Mapper.Map<ICollection<GetCashierViewModel>>(cashiers);
        }

        public GetCashierViewModel GetCashierById(int cashierId)
        {
            var cashier = _context.Cashiers.Find(cashierId);

            return Mapper.Map<GetCashierViewModel>(cashier);
        }

        public GetCashierViewModel Add(CreateCashierViewModel model)
        {
            var cashier = Mapper.Map<DAL.Models.Cashier>(model);
            if (cashier==null)
            {
                return null;
            }

            _context.Cashiers.Add(cashier);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetCashierViewModel>(cashier) : null;
        }

        public bool Update(UpdateCashierViewModel model)
        {
            var oldValue = _context.Cashiers.Find(model.ID);

            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;


            return _context.SaveChanges() > 0;
        }

        public bool Delete(int cashierId)
        {
            var cashier = _context.Cashiers.Find(cashierId);

            if (cashier == null)
            {
                return false;
            }
            _context.Cashiers.Remove(cashier);

            return _context.SaveChanges() > 0;
        }
    }
}
