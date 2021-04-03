using Financeiro.Common.Enum;
using System;

namespace Financeiro.Common.Model
{
    public class LancamentoFinanceiroApiModel
    {

        public double Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
    }
}
