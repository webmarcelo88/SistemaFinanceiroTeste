namespace Financeiro.Common.Model
{
    public class BalancoMensalModel
    {
        public string Mes { get; set; }
        public decimal ValorCredito { get; set; }
        public decimal ValorDebito { get; set; }
        public decimal ValorSaldo { get; set; }
        public int Ano { get; set; }
    }
}
