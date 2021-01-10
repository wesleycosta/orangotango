using Orangotango.Business.Models.ValueObjects;
using Orangotango.Tests.Infrastructure;
using Xunit;

namespace Orangotango.Tests
{
    public class CpfTests
    {
        [Fact]
        public void CpfIsValid_Executed_ReturnTrue()
        {
            var scenarios = new string[]
            {
                "148.550.770-70",
                "06802626012",
                "733054.944-41",
                "016790664-04",
                "339.76734454"
            };

            foreach (var cpf in scenarios)
                Assert.True(Cpf.IsValid(cpf));
        }

        [Fact]
        public void CpfIsValid_Executed_ReturnFalse()
        {
            var scenarios = new string[]
            {
                null,
                string.Empty,
                "123413123",
                "44492437810",
                "877941257871",
                "32130312319"
            };

            foreach (var cpf in scenarios)
                Assert.False(Cpf.IsValid(cpf));
        }

        [Fact]
        public void CpfFormat_Executed_ReturnCpfFormated()
        {
            var scenarios = new GenericMock<Cpf, string>[]
            {
                new GenericMock<Cpf, string>  { Object = new Cpf("28078729480"), Expected = "280.787.294-80" },
                new GenericMock<Cpf, string>  { Object = new Cpf("431.155.938-05"), Expected = "431.155.938-05" },
                new GenericMock<Cpf, string>  { Object = new Cpf("647.338.988-19"), Expected = "647.338.988-19" },
                new GenericMock<Cpf, string>  { Object = new Cpf("79284661471"), Expected = "792.846.614-71" },
                new GenericMock<Cpf, string>  { Object = new Cpf("63785815417"), Expected = "637.858.154-17" }
            };

            foreach (var cpfMock in scenarios)
                Assert.Equal(cpfMock.Object.Format(), cpfMock.Expected);
        }

        [Fact]
        public void CpfEquals_Executed_ReturnTrue()
        {
            var scenarios = new GenericMock<Cpf, Cpf>[]
            {
                new GenericMock<Cpf, Cpf>  { Object = new Cpf("280.787.294-80"), Expected = new Cpf("28078729480") },
                new GenericMock<Cpf, Cpf>  { Object = new Cpf("148.550.770-70"), Expected = new Cpf("148.550.770-70") },
                new GenericMock<Cpf, Cpf>  { Object = new Cpf("06802626012"), Expected = new Cpf("068.026.260-12") },
                new GenericMock<Cpf, Cpf>  { Object = new Cpf("733054.944-41"), Expected = new Cpf("733054.944-41") },
                new GenericMock<Cpf, Cpf>  { Object = new Cpf("016790664-04"), Expected = new Cpf("016790664-04") },
            };

            foreach (var cpf in scenarios)
                Assert.True(Cpf.Equals(cpf.Object, cpf.Expected));
        }
    }
}
