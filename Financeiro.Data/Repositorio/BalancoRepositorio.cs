using Financeiro.Common.Enum;
using Financeiro.Dao.Interface;
using Financeiro.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Financeiro.Dao.Repositorio
{
    public class BalancoRepositorio : IBalancoRepositorio
    {
        private readonly FinanceiroContext _financeiroContext;
        public BalancoRepositorio(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public List<BalancoMensal> BuscarBalancoMensal(DateTime? ano, DateTime? mesParametro)
        {
            if (ano == null)
                ano = DateTime.Now;

            var listaBalancoAgrupadoPorMes = _financeiroContext.BalancoDia
                    .Where(_ => _.Data.Year == ano.Value.Year && (mesParametro == null || _.Data.Month == ano.Value.Month))
                    .GroupBy(_ => _.Data.Month).ToList();

            var balancoMensal = new List<BalancoMensal>();

            foreach (var mes in listaBalancoAgrupadoPorMes)
            {
                balancoMensal.Add(new BalancoMensal()
                {
                    Ano = ano.Value.Year,
                    Mes = mes.Key,
                    DescricaoMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mes.Key),
                    SomaCredito = mes.Sum(_ => _.ValorCredito),
                    SomaDebito = mes.Sum(_ => _.ValorDebito),
                    SomaSaldo = mes.Sum(_ => _.ValorSaldo)
                }); ;
            }

            return balancoMensal;
        }

        public void GerarBalancoDiario()
        {
            var listaLancamentosNaoConsolidados = _financeiroContext.LancamentosFinanceiro.Where(_ => !_.Consolidado).Include(_ => _.TipoLancamento);

            var listaLancamentosAgrupadoData = listaLancamentosNaoConsolidados.GroupBy(_ => _.DataHoraLancamento.Date);

            foreach (var data in listaLancamentosAgrupadoData)
            {
                var totalCredito = data.Where(_ => _.TipoLancamento.ID == (int)TipoLancamentoEnum.Credito).Sum(_ => _.Valor);
                var totalDebito = data.Where(_ => _.TipoLancamento.ID == (int)TipoLancamentoEnum.Debito).Sum(_ => _.Valor);

                var balanco = BuscarBalancoDia(data.Key);

                if (balanco == null)
                {
                    _financeiroContext.BalancoDia.Add(new BalancoDia()
                    {
                        Data = data.Key,
                        ValorCredito = totalCredito,
                        ValorDebito = totalDebito,
                        ValorSaldo = totalCredito - totalDebito
                    });
                }
                else
                {
                    balanco.ValorCredito += totalCredito;
                    balanco.ValorDebito += totalDebito;
                    balanco.ValorSaldo = balanco.ValorCredito - balanco.ValorDebito;
                }

                data.ToList().ForEach(_ => _.Consolidado = true);
            }

            _financeiroContext.SaveChanges();
        }

        private BalancoDia BuscarBalancoDia(DateTime dataLancamento) => _financeiroContext.BalancoDia.FirstOrDefault(_ => _.Data.Date == dataLancamento);
    }
}
