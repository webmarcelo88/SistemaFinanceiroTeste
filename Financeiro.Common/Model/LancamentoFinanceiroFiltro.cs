using System;

namespace Financeiro.Common.Model
{
    public class LancamentoFinanceiroFiltro
    {
        public DateTime? DataLancamento { get; set; }
        public int? TipoLancamento { get; set; }
        public bool? Conciliado { get; set; }
    }
}
