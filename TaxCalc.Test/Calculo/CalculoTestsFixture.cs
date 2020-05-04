using AutoMoq;
using MediatR;
using Moq;
using System;
using TaxCalc.Business.Events;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Services;
using Xunit;

namespace TaxCalc.Test.Calculo
{
    [CollectionDefinition(nameof(CalculoCollection))]
    public class CalculoCollection : ICollectionFixture<CalculoTestsFixture>
    {
    }

    public class CalculoTestsFixture : IDisposable
    {
        public Mock<ICalculoService> CalculoServiceMock { get; set; }
        public Mock<IMediator> MediatorMock { get; set; }

        public CalculoService GetCalculoService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<CalculoService>();

            var calculoService = mocker.Resolve<CalculoService>();

            CalculoServiceMock = mocker.GetMock<ICalculoService>();
            MediatorMock = mocker.GetMock<IMediator>();

            return calculoService;
        }

        public void Dispose()
        {
            // nada a fazer nesse momento...
        }
    }
}
