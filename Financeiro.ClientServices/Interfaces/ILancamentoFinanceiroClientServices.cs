using Financeiro.Common.Model;
using Financeiro.Dominio;
using System.Collections.Generic;

namespace Financeiro.ClientServices.Interfaces
{
    public interface ILancamentoFinanceiroClientServices
    {
        IEnumerable<LancamentoFinanceiroModel> FiltrarLancamentosFinanceiro(LancamentoFinanceiroFiltro filtro);
        void AtualizarLancamentoFinanceiro(LancamentoFinanceiroApiUpdateModel model);
        void InserirLancamentoFinaneiro(LancamentoFinanceiroApiModel model);
        void ExcluirLancamentoFinanceiro(int id);
        LancamentoFinanceiroModel GetLancamentoFinanceiro(int id);
    }
}
