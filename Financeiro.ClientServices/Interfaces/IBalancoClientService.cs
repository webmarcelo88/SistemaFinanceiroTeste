using Financeiro.Common.Model;
using System.Collections.Generic;

namespace Financeiro.ClientServices.Interfaces
{
    public interface IBalancoClientService
    {
        IEnumerable<BalancoMensalModel> GetBalancoMensal(int? ano, int? mes);

        void GerarBalancoDiario();
    }
}
