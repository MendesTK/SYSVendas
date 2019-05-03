using System.Data.Entity.ModelConfiguration;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Infra.Data.EntityConfig
{
    class StatusVendaConfiguration : EntityTypeConfiguration<StatusVendas>
    {
        public StatusVendaConfiguration()
        {
            HasKey(sv => sv.StatusId);

            Property(sv => sv.Status)
                .IsRequired().HasMaxLength(20);

        }
    }
}
