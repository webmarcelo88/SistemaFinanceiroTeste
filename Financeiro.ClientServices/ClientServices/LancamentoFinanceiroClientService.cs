﻿using Financeiro.ClientServices.Interfaces;
using Financeiro.Common.Configuracao;
using Financeiro.Common.Constantes;
using Financeiro.Common.Helpers;
using Financeiro.Common.Model;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Financeiro.ClientServices.ClientServices
{
    public class LancamentoFinanceiroClientService : ILancamentoFinanceiroClientServices
    {
        private readonly HttpClient _httpClient = default;
        private readonly IOptions<CustomConfiguration> _customConfiguration;

        public LancamentoFinanceiroClientService(HttpClient httpClient, IOptions<CustomConfiguration> customConfiguration)
        {
            _httpClient = httpClient;
            _customConfiguration = customConfiguration;

        }

        public void AtualizarLancamentoFinanceiro(LancamentoFinanceiroApiUpdateModel model)
        {
            try
            {
                var dados = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = _httpClient.PutAsync(ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_ATUALIZAR_LANCAMENTO_FINANCEIRO), dados))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ExcluirLancamentoFinanceiro(int id)
        {
            try
            {
                var urlComParametros = $"{ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_DELETAR_LANCAMENTO_FINANCEIRO)}/{id}";

                using (var response = _httpClient.DeleteAsync(urlComParametros))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<LancamentoFinanceiroModel> FiltrarLancamentosFinanceiro(LancamentoFinanceiroFiltro filtro)
        {
            try
            {
                var urlComParametros = $"{ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_FILTRAR_LISTA_LANCAMENTO_FINANCEIRO)}?" +
                                       $"DataLancamento={filtro.DataLancamento}&" +
                                       $"TipoLancamento={filtro.TipoLancamento}&" +
                                       $"Conciliado={filtro.Conciliado}";

                using (var response = _httpClient.GetAsync(urlComParametros))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<List<LancamentoFinanceiroModel>>(retornoApi.Result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LancamentoFinanceiroModel GetLancamentoFinanceiro(int id)
        {
            try
            {
                var urlComParametros = $"{ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_BUSCAR_LANCAMENTO_FINANCEIRO)}/{id}";

                using (var response = _httpClient.GetAsync(urlComParametros))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<LancamentoFinanceiroModel>(retornoApi.Result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InserirLancamentoFinaneiro(LancamentoFinanceiroApiModel model)
        {
            try
            {
                var dados = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = _httpClient.PostAsync(ClientServiceHelpers.ConfigurarUrl(_customConfiguration, Servicos.SERVICO_INSERIR_LANCAMENTO_FINANCEIRO), dados))
                {
                    var retornoApi = response.Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
