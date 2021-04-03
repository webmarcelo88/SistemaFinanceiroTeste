using Financeiro.Common.Constantes;
using Financeiro.Dao.Interface;
using Financeiro.Dominio;
using Financeiro.Services.Interface;
using System;
using System.Collections.Generic;

namespace Financeiro.Services
{
    public class LancamentoServices : ILancamentoServices
    {
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public LancamentoServices(ILancamentoRepositorio lancamentoRepositorio)
        {
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public void AtualizarLancamento(LancamentoFinanceiro lancamentoFinanceiro)
        {
            if (_lancamentoRepositorio.ValidarLancamentoExiste(lancamentoFinanceiro.ID))
                throw new Exception(string.Format(Mensagens.MENSAGEM_LANCAMENTO_NAO_ENCONTRADO, lancamentoFinanceiro.ID));

            if (_lancamentoRepositorio.ValidarLancamentoConsolidado(lancamentoFinanceiro.ID))
                throw new Exception(Mensagens.MENSAGEM_NAO_PERMITIDO_ALTERAR_LANCAMENTO);

            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.ID))
                throw new Exception(Mensagens.MENSAGEM_NAO_EXISTE_TIPO_LANCAMENTO_CADASTRADRO);

            _lancamentoRepositorio.Atualizar(lancamentoFinanceiro);
        }

        public List<LancamentoFinanceiro> BuscarLancamentoFinanceiro(DateTime? dataLancamento, int? tipoLancamento, bool? consolidado)
        {
            return _lancamentoRepositorio.Buscar(dataLancamento, tipoLancamento, consolidado);
        }

        public LancamentoFinanceiro BuscarLancamentoFinanceiroPorId(int id)
        {
            return _lancamentoRepositorio.BuscarPorId(id);
        }

        public void ExcluirLancamentoFinanceiro(int id)
        {
            if (_lancamentoRepositorio.ValidarLancamentoExiste(id))
                throw new Exception(string.Format(Mensagens.MENSAGEM_LANCAMENTO_NAO_ENCONTRADO, id));

            if (_lancamentoRepositorio.ValidarLancamentoConsolidado(id))
                throw new Exception(Mensagens.MENSAGEM_NAO_PERMITIDO_EXCLUIR_LANCAMENTO);

            _lancamentoRepositorio.Excluir(id);
        }

        public void InserirLancamento(LancamentoFinanceiro lancamentoFinanceiro)
        {
            if (!_lancamentoRepositorio.ExisteTipoLancamento(lancamentoFinanceiro.TipoLancamento.ID))
                throw new Exception(Mensagens.MENSAGEM_NAO_EXISTE_TIPO_LANCAMENTO_CADASTRADRO);

            _lancamentoRepositorio.Inserir(lancamentoFinanceiro);
        }
    }
}
