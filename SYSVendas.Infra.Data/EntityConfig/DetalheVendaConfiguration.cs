using System.Data.Entity.ModelConfiguration;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Infra.Data.EntityConfig
{
    public class DetalheVendaConfiguration : EntityTypeConfiguration<DetalheVenda>
    {
        public DetalheVendaConfiguration()
        {
            HasKey(vp => vp.VendaProdutoId);

            HasRequired(vp => vp.Produto)
                .WithMany().HasForeignKey(vp => vp.ProdutoId);

            Property(vp => vp.Qtd)
                .IsRequired();

            Property(vp => vp.Valor)
                .IsOptional();
        }
    }
}
