using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ArmyTechTask.BLL.ViewModel.Invoice;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;
using ArmyTechTask.DAL.Database;
using ArmyTechTask.DAL.Models;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.Invoice
{
    public class InvoiceService:IInvoiceService
    {
        private readonly ArmyTechTaskDbContext _context;

        public InvoiceService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        public ICollection<GetInvoiceViewModel> GetInvoices()
        {
            var invoices = _context.InvoiceHeaders.Include(x => x.InvoiceDetails).Include(x => x.Cashier)
                .Include(x => x.Branch).ToList();

            return invoices.Select(invoice => new GetInvoiceViewModel
                {
                    ID = invoice.ID,
                    CustomerName = invoice.CustomerName,
                    InvoiceDate = invoice.Invoicedate,
                    BranchName = invoice.Branch != null ? invoice.Branch.BranchName : null,
                    CashierName = invoice.Cashier != null ? invoice.Cashier.CashierName : null,
                    Total = invoice.InvoiceDetails.Sum(x => x.ItemCount * x.ItemPrice),
                    BranchID = invoice.BranchID,
                    CashierID = invoice.CashierID,
                    InvoiceDetails = Mapper.Map<ICollection<GetInvoiceDetailsViewModel>>(invoice.InvoiceDetails)
                }).ToList();
        }

        public GetInvoiceViewModel GetInvoiceById(long invoiceHeaderId)
        {
            var invoiceHeader = _context.InvoiceHeaders.Find(invoiceHeaderId);

            return Mapper.Map<GetInvoiceViewModel>(invoiceHeader);
        }

        public GetInvoiceViewModel Add(CreateInvoiceViewModel model)
        {
            var invoiceHeader = Mapper.Map<DAL.Models.InvoiceHeader>(model);

            if (invoiceHeader==null)
            {
                return null;
            }

            invoiceHeader.Invoicedate = DateTime.Now;

            _context.InvoiceHeaders.Add(invoiceHeader);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetInvoiceViewModel>(invoiceHeader) : null;
        }

        public bool Update(UpdateInvoiceViewModel model)
        {
            var oldValue = _context.InvoiceHeaders.Find(model.ID);

            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;


            return _context.SaveChanges() > 0;
        }

        public bool Delete(long invoiceHeaderId)
        {
            var invoiceHeader = _context.InvoiceHeaders.Find(invoiceHeaderId);

            if (invoiceHeader == null)
            {
                return false;
            }

            if (invoiceHeader.InvoiceDetails != null && invoiceHeader.InvoiceDetails.Any())
            {
                foreach (var invoiceItem in invoiceHeader.InvoiceDetails.ToList())
                {
                    _context.InvoiceDetails.Remove(invoiceItem);
                }
            }

            _context.InvoiceHeaders.Remove(invoiceHeader);

            return _context.SaveChanges() > 0;
        }

        private ICollection<GetInvoiceDetailsViewModel> MapInvoiceDetails(ICollection<InvoiceDetail> items)
        {
            return items.Select(invoiceItem => new GetInvoiceDetailsViewModel
            {
                ID = invoiceItem.ID,
                ItemPrice = invoiceItem.ItemPrice,
                ItemCount = invoiceItem.ItemCount,
                InvoiceHeaderID = invoiceItem.InvoiceHeaderID,
                ItemName = invoiceItem.ItemName,
                Total = invoiceItem.ItemCount * invoiceItem.ItemPrice
            }).ToList();
        }
    }
}
