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
                .IsRequired();

            HasRequired(v => v.StatusVendas)
                .WithMany().HasForeignKey(v => v.StatusId);

            HasRequired(v => v.Cliente)
                .WithMany().HasForeignKey(v => v.ClienteId);
            
        }
    }
}
