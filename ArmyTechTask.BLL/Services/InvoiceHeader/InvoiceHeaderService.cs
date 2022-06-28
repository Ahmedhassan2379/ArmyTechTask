using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.InvoiceHeader;
using ArmyTechTask.DAL.Database;
using ArmyTechTask.DAL.Models;
using AutoMapper;

namespace ArmyTechTask.BLL.Services.InvoiceHeader
{
    public class InvoiceHeaderService:IInvoiceHeaderService
    {
        private readonly ArmyTechTaskDbContext _context;

        public InvoiceHeaderService(ArmyTechTaskDbContext context)
        {
            _context = context;
        }
        public ICollection<GetInvoiceHeaderViewModel> GetInvoiceHeaders()
        {
            var invoiceHeaders = _context.InvoiceHeaders.ToList();

            return Mapper.Map<ICollection<GetInvoiceHeaderViewModel>>(invoiceHeaders);
        }

        public GetInvoiceHeaderViewModel GetInvoiceHeaderById(long invoiceHeaderId)
        {
            var invoiceHeader = _context.InvoiceHeaders.Find(invoiceHeaderId);

            return Mapper.Map<GetInvoiceHeaderViewModel>(invoiceHeader);
        }

        public GetInvoiceHeaderViewModel Add(CreateInvoiceHeaderViewModel model)
        {
            var invoiceHeader = Mapper.Map<DAL.Models.InvoiceHeader>(model);

            if (invoiceHeader==null)
            {
                return null;
            }

            _context.InvoiceHeaders.Add(invoiceHeader);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetInvoiceHeaderViewModel>(invoiceHeader) : null;
        }

        public bool Update(UpdateInvoiceHeaderViewModel model)
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
            _context.InvoiceHeaders.Remove(invoiceHeader);

            return _context.SaveChanges() > 0;
        }
    }
}
