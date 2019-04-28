using AutoMapper;
using SYSVendas.Domain.Entities;
using SYSVendas.MVC.ViewModels;

namespace SYSVendas.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Venda, VendaViewModel>();
        }
    }
}