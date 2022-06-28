using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyTechTask.BLL.Services.Branch;
using ArmyTechTask.BLL.Services.Cashier;
using ArmyTechTask.BLL.Services.Invoice;
using ArmyTechTask.BLL.Services.InvoiceDetails;
using ArmyTechTask.BLL.ViewModel.Invoice;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;
using ArmyTechTask.DAL.Database;
using AutoMapper;

namespace ArmyTechTask.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceDetailService _invoiceDetailService;
        private readonly IInvoiceService _invoiceService;
        private readonly IBranchService _branchService;
        private readonly ICashierService _cashierService;

        public InvoiceController()
        {
            var dbContext = new ArmyTechTaskDbContext();
            _invoiceDetailService = new InvoiceDetailService(dbContext);
            _invoiceService = new InvoiceService(dbContext);
            _branchService = new BranchService(dbContext);
            _cashierService = new CashierService(dbContext);
        }

        [HttpGet]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult InvoiceList()
        {
            var invoices = _invoiceService.GetInvoices().ToList();
            return PartialView(invoices);
        }

        #region Invoice CRUD Operations

        [HttpGet]
        public ActionResult Create()
        {
            var branches = _branchService.GetBranches();
            var branchesList = branches.Select(b => new SelectListItem
            {
                Text = b.BranchName,
                Value = b.ID.ToString()
            });

            var createVm = new CreateInvoiceViewModel
            {
                Branches = branchesList
            };
            return PartialView(createVm);
        }

        [HttpPost]
        public ActionResult Create(CreateInvoiceViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = _invoiceService.Add(model);

                if (result != null && result.ID != default)
                {
                    var invoices = _invoiceService.GetInvoices();
                    return PartialView(nameof(InvoiceList), invoices);
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            if (id == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoice = _invoiceService.GetInvoiceById(id);

            if (invoice == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var branches = _branchService.GetBranches();
            var branchesList = branches.Select(b => new SelectListItem
            {
                Text = b.BranchName,
                Value = b.ID.ToString(),
                Selected = b.ID == invoice.BranchID
            });

            var editViewModel = Mapper.Map<UpdateInvoiceViewModel>(invoice);

            editViewModel.Branches = branchesList;

            if (!invoice.CashierID.HasValue)
            {
                return PartialView(editViewModel);
            }

            var cashiers = _cashierService.GetCashiersByBranchId(invoice.BranchID);
            var cashiersList = cashiers.Select(c => new SelectListItem
            {
                Text = c.CashierName,
                Value = c.ID.ToString(),
                Selected = invoice.CashierID.Value == c.ID
            });

            editViewModel.Cashiers = cashiersList;

            return PartialView(editViewModel);
        }

        [HttpPut]
        public ActionResult Edit(UpdateInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _invoiceService.Update(model);

                if (!result)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                var invoices = _invoiceService.GetInvoices();

                return PartialView(nameof(InvoiceList), invoices);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            if (id == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = _invoiceService.Delete(id);

            if (!result)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var invoices = _invoiceService.GetInvoices();

            return PartialView(nameof(InvoiceList), invoices);
        }

        #endregion


        #region Invoice Details (Items) CRUD Operations

        [HttpGet]
        public ActionResult CreateInvoiceItem(long invoiceId)
        {
            if (invoiceId == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var createVm = new CreateInvoiceDetailsViewModel
            {
                InvoiceHeaderID = invoiceId,
                ItemCount = 1,
                ItemPrice = 1
            };

            return PartialView(createVm);
        }

        [HttpPost]
        public ActionResult CreateInvoiceItem(CreateInvoiceDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _invoiceDetailService.Add(model);

                if (result == null || result.ID == default)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
                }

                var invoices = _invoiceService.GetInvoices();

                return PartialView(nameof(InvoiceList), invoices);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        public ActionResult EditInvoiceItem(long id)
        {
            if (id == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoiceItem = _invoiceDetailService.GetInvoiceDetailById(id);

            if (invoiceItem == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var invoiceItemVm = Mapper.Map<UpdateInvoiceDetailsViewModel>(invoiceItem);

            return PartialView(invoiceItemVm);
        }

        [HttpPut]
        public ActionResult EditInvoiceItem(UpdateInvoiceDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _invoiceDetailService.Update(model);

                if (result)
                {
                    var invoices = _invoiceService.GetInvoices();
                    return PartialView(nameof(InvoiceList), invoices);
                }

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        public ActionResult DeleteInvoiceItem(long id)
        {
            if (id == default)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var result = _invoiceDetailService.Delete(id);

            if (!result)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            var invoices = _invoiceService.GetInvoices();

            return PartialView(nameof(InvoiceList), invoices);
        }

        #endregion

    }
}