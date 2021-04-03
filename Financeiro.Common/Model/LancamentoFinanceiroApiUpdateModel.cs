using Financeiro.Common.Enum;

namespace Financeiro.Common.Model
{
    public class LancamentoFinanceiroApiUpdateModel
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public TipoLancamentoEnum TipoLancamento { get; set; }
    }
}
