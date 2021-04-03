using Financeiro.Dao.Interface;
using Financeiro.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financeiro.Dao.Repositorio
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private readonly FinanceiroContext _financeiroContext;

        public LancamentoRepositorio(FinanceiroContext financeiroContext)
        {
            _financeiroContext = financeiroContext;
        }

        public void Atualizar(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var lancamento = _financeiroContext.LancamentosFinanceiro.FirstOrDefault(_ => _.ID == lancamentoFinanceiro.ID);

            var tipoLancamento = _financeiroContext.TiposLancamento.FirstOrDefault(_ => _.ID == lancamentoFinanceiro.TipoLancamento.ID);

            lancamento.TipoLancamento = tipoLancamento;
            lancamento.Valor = lancamentoFinanceiro.Valor;

            _financeiroContext.SaveChanges();
        }

        public List<LancamentoFinanceiro> Buscar(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado)
        {
            return _financeiroContext.LancamentosFinanceiro.Include(_ => _.TipoLancamento)
                        .Where(_ =>
                                (dataLancamento == null || _.DataHoraLancamento.Date == dataLancamento) &&
                                (tipoLancamento == null || _.TipoLancamento.ID == tipoLancamento) &&
                                (consolidado == null || _.Consolidado == consolidado)
                             ).ToList();
        }

        public void Excluir(int id)
        {
            var lancamento = _financeiroContext.LancamentosFinanceiro.FirstOrDefault(_ => _.ID == id);

            _financeiroContext.LancamentosFinanceiro.Remove(lancamento);

            _financeiroContext.SaveChanges();
        }

        public void Inserir(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var tipoLancamento = _financeiroContext.TiposLancamento.FirstOrDefault(_ => _.ID == lancamentoFinanceiro.TipoLancamento.ID);

            lancamentoFinanceiro.TipoLancamento = tipoLancamento;

            _financeiroContext.LancamentosFinanceiro.Add(lancamentoFinanceiro);

            _financeiroContext.SaveChanges();
        }

        public bool ExisteTipoLancamento(int id) => _financeiroContext.TiposLancamento.Any(_ => _.ID == id);

        public bool ValidarLancamentoExiste(long id) =>
            _financeiroContext.LancamentosFinanceiro.FirstOrDefault(_ => _.ID == id) == null;

        public bool ValidarLancamentoConsolidado(long id) =>
            _financeiroContext.LancamentosFinanceiro.FirstOrDefault(_ => _.ID == id).Consolidado;

        public LancamentoFinanceiro BuscarPorId(int id) => _financeiroContext.LancamentosFinanceiro.Include(_ => _.TipoLancamento).FirstOrDefault(_ => _.ID == id);
        
    }
}
