using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArmyTechTask.BLL.ViewModel.Branch;
using ArmyTechTask.BLL.ViewModel.Cashier;
using ArmyTechTask.BLL.ViewModel.City;
using ArmyTechTask.BLL.ViewModel.Invoice;
using ArmyTechTask.BLL.ViewModel.InvoiceDetails;
using ArmyTechTask.DAL.Models;
using AutoMapper;

namespace ArmyTechTask.BLL.Helpers.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateBranchViewModel, Branch>(MemberList.None);
            CreateMap<UpdateBranchViewModel, Branch>(MemberList.None).ReverseMap();
            CreateMap<GetBranchViewModel, UpdateBranchViewModel>(MemberList.None);
            CreateMap<Branch, GetBranchViewModel>(MemberList.None);


            CreateMap<CreateCityViewModel, City>(MemberList.None);
            CreateMap<UpdateCityViewModel, City>(MemberList.None).ReverseMap();
            CreateMap<GetCityViewModel, UpdateCityViewModel>(MemberList.None);
            CreateMap<City, GetCityViewModel>(MemberList.None);


            CreateMap<CreateInvoiceViewModel, InvoiceHeader>(MemberList.None);
            CreateMap<UpdateInvoiceViewModel, InvoiceHeader>(MemberList.None).ReverseMap();
            CreateMap<GetInvoiceViewModel, UpdateInvoiceViewModel>(MemberList.None);
            CreateMap<InvoiceHeader, GetInvoiceViewModel>(MemberList.None)
                .ForMember(dest => dest.InvoiceDate, opt => opt.MapFrom(src => src.Invoicedate))
                .ForMember(dest => dest.BranchName,
                    opt => opt.MapFrom(src => src.Branch != null ? src.Branch.BranchName : null))
                .ForMember(dest => dest.CashierName,
                    opt => opt.MapFrom(src => src.Cashier != null ? src.Cashier.CashierName : null))
                .ForMember(dest => dest.Total,
                    opt => opt.MapFrom(src =>
                        src.InvoiceDetails != null ? src.InvoiceDetails.Sum(x => x.ItemCount * x.ItemPrice) : default));




            CreateMap<CreateInvoiceDetailsViewModel, InvoiceDetail>(MemberList.None);
            CreateMap<UpdateInvoiceDetailsViewModel, InvoiceDetail>(MemberList.None).ReverseMap();
            CreateMap<GetInvoiceDetailsViewModel, UpdateInvoiceDetailsViewModel>(MemberList.None);
            CreateMap<InvoiceDetail, GetInvoiceDetailsViewModel>(MemberList.None)
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.ItemPrice * src.ItemCount));
                



            CreateMap<CreateCashierViewModel, Cashier>(MemberList.None);
            CreateMap<UpdateCashierViewModel, Cashier>(MemberList.None).ReverseMap();
            CreateMap<GetCashierViewModel, UpdateCashierViewModel>(MemberList.None);
            CreateMap<Cashier, GetCashierViewModel>(MemberList.None);
        }
    }
}
