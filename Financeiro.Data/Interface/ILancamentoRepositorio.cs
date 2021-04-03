using Financeiro.Dominio;
using System;
using System.Collections.Generic;

namespace Financeiro.Dao.Interface
{
    public interface ILancamentoRepositorio
    {
        void Inserir(LancamentoFinanceiro lancamentoFinanceiro);
        void Atualizar(LancamentoFinanceiro lancamentoFinanceiro);
        List<LancamentoFinanceiro> Buscar(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado);
        bool ExisteTipoLancamento(int id);
        void Excluir(int id);
        bool ValidarLancamentoExiste(long id);
        bool ValidarLancamentoConsolidado(long id);
        LancamentoFinanceiro BuscarPorId(int id);
    }
}
