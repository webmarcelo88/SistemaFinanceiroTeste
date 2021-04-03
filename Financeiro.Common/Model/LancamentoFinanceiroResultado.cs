namespace Financeiro.Common.Model
{
    public class LancamentoFinanceiroResultado
    {
        public string Id { get; set; }
        public string DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public string TipoLancamento { get; set; }
        public string Conciliado { get; set; }
    }
}
