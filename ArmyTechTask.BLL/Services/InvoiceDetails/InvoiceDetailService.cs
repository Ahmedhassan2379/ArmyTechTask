using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;
using ArmyTechTask.DAL.Database;
using ArmyTechTask.DAL.Models;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.InvoiceDetails
{
    public class InvoiceDetailService:IInvoiceDetailService
    {
        private readonly ArmyTechTaskDbContext _context;

        public InvoiceDetailService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        public ICollection<GetInvoiceDetailsViewModel> GetInvoiceDetails()
        {
            var invoiceDetails = _context.InvoiceDetails.ToList();

            return Mapper.Map<ICollection<GetInvoiceDetailsViewModel>>(invoiceDetails);
        }

        public GetInvoiceDetailsViewModel GetInvoiceDetailById(long invoiceDetailId)
        {
            var invoiceDetail = _context.InvoiceDetails.Find(invoiceDetailId);

            return Mapper.Map<GetInvoiceDetailsViewModel>(invoiceDetail);
        }

        public GetInvoiceDetailsViewModel Add(CreateInvoiceDetailsViewModel model)
        {
            var invoiceDetail = Mapper.Map<InvoiceDetail>(model);

            if (invoiceDetail==null)
            {
                return null;
            }

            _context.InvoiceDetails.Add(invoiceDetail);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetInvoiceDetailsViewModel>(invoiceDetail) : null;
        }

        public bool Update(UpdateInvoiceDetailsViewModel model)
        {
            var oldValue = _context.InvoiceDetails.Find(model.ID);

            if (oldValue == null)
            {
                return false;
            }

            Mapper.Map(model, oldValue);

            _context.Entry(oldValue).State = EntityState.Modified;


            return _context.SaveChanges() > 0;
        }

        public bool Delete(long invoiceDetailId)
        {
            var invoiceDetail = _context.InvoiceDetails.Find(invoiceDetailId);

            if (invoiceDetail == null)
            {
                return false;
            }
            _context.InvoiceDetails.Remove(invoiceDetail);

            return _context.SaveChanges() > 0;
        }
    }
}
