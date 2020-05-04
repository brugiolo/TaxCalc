using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalc.Api;
using Xunit;

namespace TaxCalc.IntegrationTests.API
{
    public class CalculoTests
    {
        private readonly HttpClient _httpClient;
        
        public CalculoTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _httpClient = server.CreateClient();
        }

        [Theory(DisplayName = "Efetua Saque via api")]
        [InlineData("GET", 2, 3)]
        public async Task ExecutarCalculoJurosSucesso(string httpMethod, decimal valorInicial, int tempo)
        {
            var requisicao = new HttpRequestMessage(
                new HttpMethod(httpMethod), string.Format("/CalculaJuros?valorInicial={0}&tempo={1}", valorInicial, tempo));

            var resposta = await _httpClient.SendAsync(requisicao);

            resposta.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        [Theory]
        [InlineData("GET", 2, -3)]
        public async Task ExecutarCalculoJurosFalha(string httpMethod, decimal valorInicial, int tempo)
        {
            var requisicao = new HttpRequestMessage(
                new HttpMethod(httpMethod), string.Format("/CalculaJuros?valorInicial={0}&tempo={1}", valorInicial, tempo));

            var resposta = await _httpClient.SendAsync(requisicao);

            Assert.Equal(HttpStatusCode.BadRequest, resposta.StatusCode);
        }
    }
}
