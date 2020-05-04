using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalc.Business.Events;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Services
{
    public class CalculoService : ICalculoService
    {
        static string BaseUriTaxaJuros = "https://localhost:44311/";
        private readonly IMediator _mediator;

        public CalculoService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Calculo> CalcularResultado(decimal valorInicial, int tempo)
        {
            if (valorInicial <= 0)
                throw new Exception("O valor inicial deve maior do que 0 (zero).");
            if (tempo <= 0)
                throw new Exception("O tempo deve ser maior do que 0 (zero).");

            var valorJuros = await ObterTaxaJuros();
            var basePotencia = valorInicial * (1 + valorJuros);
            var resultadoPotencia = Math.Pow(Convert.ToDouble(basePotencia), tempo);
            var resultado = Math.Truncate(100 * resultadoPotencia) / 100;

            await _mediator.Publish(new NotificacaoTeste("CalculoService - Calculo realizado com sucesso."));

            return new Calculo 
            {  
                ValorInicial = valorInicial,
                Tempo = tempo,
                Resultado = resultado
            };
        }

        private async Task<decimal> ObterTaxaJuros()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(BaseUriTaxaJuros);
            httpClient.Timeout = TimeSpan.FromSeconds(60);
            httpClient.DefaultRequestHeaders.Accept.Clear();

            var response = await httpClient.GetAsync("TaxaJuros");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var taxaJuros = await Task.Run(() => JsonConvert.DeserializeObject<TaxaJuros>(content));

                return taxaJuros.Valor;
            }
            else
            {
                throw new Exception("Não foi possível obter a taxa de juros.");
            }
        }
    }
}
