using System.Data.Entity.ModelConfiguration;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Infra.Data.EntityConfig
{
    public class VendaConfiguration : EntityTypeConfiguration<Venda>
    {
        public VendaConfiguration()
        {
            HasKey(v => v.VendaId);

            Property(v => v.DataVenda)
                .IsRequired();

            Property(v => v.ValorTotal)
                .IsOptional();
            /*
            HasMany(v => v.Produtos)
                .WithMany()
                .Map(pv =>
                {
                    pv.MapLeftKey("VendaId");
                    pv.MapRightKey("ProdutoId");
                    pv.ToTable("VendasProdutos");
                });*/
        }
    }
}
