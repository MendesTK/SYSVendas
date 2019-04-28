using System.Data.Entity.ModelConfiguration;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Nome)
                .IsRequired().HasMaxLength(50);

            Property(p => p.Valor)
                .IsRequired();

            Property(p => p.DataCadastro)
                .IsRequired();
        }
    }
}
