using System.Data.Entity.ModelConfiguration;
using SYSVendas.Domain.Entities;

namespace SYSVendas.Infra.Data.EntityConfig
{
    class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome)
                .IsRequired().HasMaxLength(30);

            Property(c => c.Sobrenome)
                .IsOptional().HasMaxLength(100);

            Property(c => c.DataNascimento)
                .IsOptional();

            Property(c => c.cpf)
                .IsRequired().HasMaxLength(11);
        }
    }
}
