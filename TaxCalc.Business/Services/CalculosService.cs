using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Services
{
    public class CalculosService : ICalculosService
    {
        static string BaseUriTaxaJuros = "https://localhost:44311/";

        public async Task<Calculo> CalcularResultado(decimal valorInicial, int tempo)
        {
            var valorJuros = await ObterTaxaJuros();
            var basePotencia = valorInicial * (1 + valorJuros);
            var resultadoPotencia = Math.Pow(Convert.ToDouble(basePotencia), tempo);
            var resultado = Math.Truncate(100 * resultadoPotencia) / 100;

            return new Calculo 
            {  
                ValorInicial = valorInicial,
                Tempo = tempo,
                Resultado = resultado
            };
        }

        public async Task<decimal> ObterTaxaJuros()
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
