using Financeiro.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Financeiro.Dao
{
    public class FinanceiroContext : DbContext
    {
        public FinanceiroContext(DbContextOptions<FinanceiroContext> options) : base(options)
        { 
        }

        public DbSet<LancamentoFinanceiro> LancamentosFinanceiro { get; set; }
        public DbSet<TipoLancamento> TiposLancamento { get; set; }
        public DbSet<BalancoDia> BalancoDia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
