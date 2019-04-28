using AutoMapper;
using SYSVendas.Domain.Entities;
using SYSVendas.MVC.ViewModels;

namespace SYSVendas.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<VendaViewModel, Venda>();
        }
    }
}