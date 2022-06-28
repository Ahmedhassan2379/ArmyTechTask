using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ArmyTechTask.BLL.Exceptions;
using ArmyTechTask.BLL.Services.Branch;
using ArmyTechTask.BLL.Services.Cashier;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.DAL.Database;
using ArmyTechTask.DAL.Models;

namespace ArmyTechTask.Controllers
{
    public class CashierController : Controller
    {
        private readonly ICashierService _cashierService;
        private readonly IBranchService _branchService;
        public CashierController()
        {
            var dbContext = new ArmyTechTaskDbContext();
            _cashierService = new CashierService(dbContext);
            _branchService = new BranchService(dbContext);
        }
        // GET: Cashier
        public ActionResult Index()
        {
            var cashiers = _cashierService.GetCashiers().ToList();
            return View(cashiers);
        }
        [HttpGet]
        public ActionResult CreateCashier()
        {
            var branches = _branchService.GetBranches().ToList();
            var viewmodel = new CreateCashierViewModel()
            {
                 Branches = branches
            };
            return View("CreateCashier", viewmodel);
        }

        [HttpPost]
        public ActionResult CreateCashier(CreateCashierViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var x = _cashierService.Add(model);

                    return RedirectToAction("Index", "Cashier");
                }
                catch (Exception ex)
                {
                    if (ex is CashierNameAlreadyExistException)
                    {
                        ModelState.AddModelError(nameof(Cashier.CashierName), ex.Message);
                    }
                }
            }

            var branches = _branchService.GetBranches().ToList();
            var viewmodel = new CreateCashierViewModel()
            {
                CashierName = model.CashierName,
                Branches = branches
            };

            return View("CreateCashier",viewmodel);
        }
        [HttpGet]
        public ActionResult UpdateCashier(int id)
        {
            var cashier = _cashierService.GetCashierById(id);
            var branches = _branchService.GetBranchesForUpdateCashier(id);
            var viewmodel = new UpdateCashierViewModel()
            {
               Branches = branches,
                ID = cashier.ID,
               CashierName = cashier.CashierName,
               BranchID = cashier.BranchID

            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult UpdateCashier(UpdateCashierViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _cashierService.Update(model);
                    return RedirectToAction("Index", "Cashier");
                }
                catch (Exception ex)
                {
                    if (ex is CashierNameAlreadyExistException)
                    {
                        ModelState.AddModelError(nameof(Cashier.CashierName), ex.Message);
                    }
                }
            }

            return View(model);
        }

        public ActionResult DeleteCashier(int id)
        {
            if (id == default)
            {
                return RedirectToAction("Index", "Cashier");
            }

            var result = _cashierService.Delete(id);

            return RedirectToAction("Index", "Cashier", result);
        }

        #region JSON
        [HttpGet]
        public ActionResult GetCashiersByBranchId(int branchId)
        {
            if (branchId == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cashiers = _cashierService.GetCashiersByBranchId(branchId);

            return Json(cashiers, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}