using System;
using System.Collections.Generic;

namespace Financeiro.Common.Model.ViewModel
{
    public class LancamentoFinanceiroFiltroViewModel
    {
        public LancamentoFinanceiroFiltroViewModel()
        {
            ListaLancamentoFinanceiro = new List<LancamentoFinanceiroViewModel>();
        }

        public DateTime? DataLancamento { get; set; }
        public int? TipoLancamento { get; set; }
        public bool? Consolidado { get; set; }
        public List<LancamentoFinanceiroViewModel> ListaLancamentoFinanceiro { get; set; }
    }
}
