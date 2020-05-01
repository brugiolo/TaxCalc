using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalc.Business.Models;

namespace TaxCalc.Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            ObterValorTaxaJuros();
        }

        static async void ObterValorTaxaJuros()
        {
            var baseUriTaxaJuros = "https://localhost:44311/";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUriTaxaJuros);
            httpClient.Timeout = TimeSpan.FromSeconds(60);
            httpClient.DefaultRequestHeaders.Accept.Clear();

            var response = await httpClient.GetAsync("TaxaJuros");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var taxaJuros = await Task.Run(() => JsonConvert.DeserializeObject<TaxaJuros>(content));

                Console.WriteLine("valor: " + taxaJuros.Valor);
            }
        }

        static void CalcularDuasCasasDecimais()
        {
            var valor = 3.56953558m;

            var resultado = Math.Truncate(100 * valor) / 100;

            Console.WriteLine("valor: " + valor);
            Console.WriteLine("");
            Console.WriteLine("resultado: " + resultado);
        }
    }
}
