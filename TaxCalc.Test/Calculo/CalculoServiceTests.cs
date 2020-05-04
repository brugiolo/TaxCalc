using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TaxCalc.Test.Calculo
{
    [Collection(nameof(CalculoCollection))]
    public class CalculoServiceTests
    {
        public CalculoTestsFixture Fixture { get; set; }

        public CalculoServiceTests(CalculoTestsFixture fixture)
        {
            Fixture = fixture;
        }

        //[Fact(DisplayName = "Realizar Calculo com sucesso")]
        //[Trait("Categoria", "Calculo Service Tests")]
        //public async Task CalculoService_RealizarCalculo_Sucesso()
        //{
        //    var calculoService = Fixture.GetCalculoService();

        //    await calculoService.CalcularResultado(1, 2);

        //    Fixture.CalculoServiceMock.Verify(r => r.CalcularResultado(1, 2), Times.Once);
        //    Fixture.MediatorMock.Verify(m => m.Publish(It.IsAny<string>(), CancellationToken.None), Times.Once);
        //}
    }
}
