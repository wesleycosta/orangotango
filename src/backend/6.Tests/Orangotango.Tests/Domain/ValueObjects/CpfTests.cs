using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;
using Xunit;

namespace Orangotango.Tests
{
    public class CpfTests
    {
        [Theory]
        [InlineData("148.550.770-70")]
        [InlineData("06802626012")]
        [InlineData("733054.944-41")]
        [InlineData("016790664-04")]
        [InlineData("339.76734454")]
        public void CpfIsValid_Executed_ReturnTrue(string cpf)
        {
            Assert.True(Cpf.IsValid(cpf));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123413123")]
        [InlineData("44492437810")]
        [InlineData("877941257871")]
        [InlineData("32130312319")]
        public void CpfIsValid_Executed_ReturnFalse(string cpf)
        {
            Assert.False(Cpf.IsValid(cpf));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123413123")]
        [InlineData("44492437810")]
        [InlineData("877941257871")]
        [InlineData("32130312319")]
        public void CpfCreateWithInvalidValue_Executed_ReturnException(string cpf)
        {
            var exception = Record.Exception(() => new Cpf(cpf));
            Assert.NotNull(exception);
            Assert.IsType<DomainException>(exception);
        }

        [Theory]
        [InlineData("28078729480", "280.787.294-80")]
        [InlineData("431.155.938-05", "431.155.938-05")]
        [InlineData("647.338.988-19", "647.338.988-19")]
        [InlineData("79284661471", "792.846.614-71")]
        [InlineData("63785815417", "637.858.154-17")]
        public void CpfFormat_Executed_ReturnCpfFormated(string cpfNumber, string expected)
        {
            var cpfFormated = new Cpf(cpfNumber).Format();
            Assert.Equal(cpfFormated, expected);
        }

        [Theory]
        [InlineData("280.787.294-80", "28078729480")]
        [InlineData("148.550.770-70", "148.550.770-70")]
        [InlineData("06802626012", "068.026.260-12")]
        [InlineData("733054.944-41", "733054.944-41")]
        [InlineData("016790664-04", "016790664-04")]
        public void CpfEquals_Executed_ReturnTrue(string cpfNumber, string expected)
        {
            Assert.True(Equals(new Cpf(cpfNumber), new Cpf(expected)));
        }
    }
}
