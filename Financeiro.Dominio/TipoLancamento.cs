using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.Dominio
{
    public class TipoLancamento
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public List<LancamentoFinanceiro> LancamentoFinanceiro { get; set; }
    }
}
