using System;

namespace Financeiro.Common.Model
{
    public class LancamentoFinanceiroModel
    {
        public long Id { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public int TipoLancamento { get; set; }
        public bool Conciliado { get; set; }
    }
}
