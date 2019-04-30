using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using SYSVendas.Domain.Entities;
using SYSVendas.Infra.Data.EntityConfig;
using SYSVendas.Infra.Data.Repositories;

namespace SYSVendas.Infra.Data.Contexto
{
    public class SYSVendasContext : DbContext
    {
        public SYSVendasContext()
            : base("SYSVendas")
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<DetalheVenda> VendasProdutos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(255));

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new VendaConfiguration());
            modelBuilder.Configurations.Add(new DetalheVendaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataVenda") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataVenda").CurrentValue = DateTime.Now;
                    //SaveVenda(entry.GetType().GetProperty("VendaId"));
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataVenda").IsModified = false;
                    //SaveVenda(entry.GetType().GetProperty("VendaId"));
                }
            }

            return base.SaveChanges();
        }

        private readonly DetalheVendaRepository _detalheVendaRepository;

        void SaveVenda(PropertyInfo id)
        {
            
        }
    }

}
