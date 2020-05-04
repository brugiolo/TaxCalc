using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxCalc.Api;
using Xunit;

namespace TaxCalc.IntegrationTests.API
{
    public class InfoTests
    {
        private readonly HttpClient _httpClient;

        public InfoTests()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _httpClient = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task ExecutarShowMeTheCode(string httpMethod)
        {
            var requisicao = new HttpRequestMessage(new HttpMethod(httpMethod), "/ShowMeTheCode");
            var resposta = await _httpClient.SendAsync(requisicao);

            resposta.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }
    }
}
