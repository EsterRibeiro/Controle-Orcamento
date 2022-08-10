using Controle_Orcamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Controle_Orcamento.Infra.Data
{
    public class ControleOrcamentoContext : DbContext
    {
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ControleDeOrcamento;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Despesa>().HasKey(x => x.Id);
            builder.Entity<Despesa>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<Despesa>().Property(x => x.Descricao).HasMaxLength(500);
            builder.Entity<Despesa>().Property(x => x.Data).HasColumnType("Datetime").IsRequired();
            builder.Entity<Despesa>().Property(x => x.Valor).HasColumnType("Decimal(19,5)").HasDefaultValue(0.0);

            builder.Entity<Receita>().HasKey(x => x.Id);
            builder.Entity<Receita>().Property(x => x.Id).ValueGeneratedOnAdd(); ;
            builder.Entity<Receita>().Property(x => x.Descricao).HasMaxLength(500);
            builder.Entity<Receita>().Property(x => x.Data).HasColumnType("Datetime").IsRequired();
            builder.Entity<Receita>().Property(x => x.Valor).HasColumnType("Decimal(19,5)").IsRequired();
        }
    }
}
