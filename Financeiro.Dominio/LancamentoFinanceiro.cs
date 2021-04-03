using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.Dominio
{
    public class LancamentoFinanceiro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        public DateTime DataHoraLancamento { get; set; }
        public double Valor { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public bool Consolidado { get; set; }
    }
}
