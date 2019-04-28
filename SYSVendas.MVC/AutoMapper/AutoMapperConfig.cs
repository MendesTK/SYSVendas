using AutoMapper;

namespace SYSVendas.MVC.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void ResgisterMapping()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });

        }
    }
}