using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Financeiro.Dominio
{
    public class BalancoDia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public double ValorCredito { get; set; }
        public double ValorDebito { get; set; }
        public double ValorSaldo { get; set; }

    }
}
