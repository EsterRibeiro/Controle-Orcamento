using Controle_Orcamento.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Controle_Orcamento.Infra.Data
{
    public class ControleOrcamentoContext : DbContext
    {
        public DbSet<DespesaDto> Categories { get; set; }
        public DbSet<ReceitaDto> Receitas { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ControleDeOrcamento;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<DespesaDto>().HasKey(x => x.Id);
            builder.Entity<DespesaDto>().Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Entity<DespesaDto>().Property(x => x.Descricao).HasMaxLength(500);
            builder.Entity<DespesaDto>().Property(x => x.Data).HasColumnType("Datetime").IsRequired();
            builder.Entity<DespesaDto>().Property(x => x.Valor).HasColumnType("Decimal(19,5)").HasDefaultValue(0.0);

            builder.Entity<ReceitaDto>().HasKey(x => x.Id);
            builder.Entity<ReceitaDto>().Property(x => x.Id).ValueGeneratedOnAdd(); ;
            builder.Entity<ReceitaDto>().Property(x => x.Descricao).HasMaxLength(500);
            builder.Entity<ReceitaDto>().Property(x => x.Data).HasColumnType("Datetime").IsRequired();
            builder.Entity<ReceitaDto>().Property(x => x.Valor).HasColumnType("Decimal(19,5)").IsRequired();
        }
    }
}
