using Financeiro.Dominio;
using System;
using System.Collections.Generic;

namespace Financeiro.Services.Interface
{
    public interface IBalancoServices
    {
        void GerarBalancoDiario();
        List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro);
    }
}
