using Financeiro.Dominio;
using System;
using System.Collections.Generic;

namespace Financeiro.Dao.Interface
{
    public interface IBalancoRepositorio
    {
        void GerarBalancoDiario();
        List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro);
    }
}
