using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.DAL.Database;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.Branch
{
    public class BranchService : IBranchService
    {
        private readonly ArmyTechTaskDbContext _context;

        public BranchService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        public ICollection<GetBranchViewModel> GetBranches()
        {
            var branches = _context.Branches.ToList();

            return Mapper.Map<ICollection<GetBranchViewModel>>(branches);
        }

        public GetBranchViewModel GetBranchById(int branchId)
        {
            var branch = _context.Branches.Find(branchId);

            return Mapper.Map<GetBranchViewModel>(branch);
        }

        public ICollection<GetBranchViewModel> GetBranchesForUpdateCashier(int cashierId)
        {
            var branches = _context.Branches.Where(x => x.ID != cashierId).ToList();

            return Mapper.Map<ICollection<GetBranchViewModel>>(branches);
        }

        public GetBranchViewModel Add(CreateBranchViewModel model)
        {
            var branch = Mapper.Map<DAL.Models.Branch>(model);

            if (branch == null)
            {
                return null;
            }

            _context.Branches.Add(branch);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetBranchViewModel>(branch) : null;
        }

        public bool Update(UpdateBranchViewModel model)
        {
            var oldValue = _context.Branches.Find(model.ID);

            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;


            return _context.SaveChanges() > 0;
        }


        public bool Delete(int branchId)
        {
            var branch = _context.Branches.Find(branchId);

            if (branch == null)
            {
                return false;
            }
            _context.Branches.Remove(branch);

            return _context.SaveChanges() > 0;
        }
    }
}
