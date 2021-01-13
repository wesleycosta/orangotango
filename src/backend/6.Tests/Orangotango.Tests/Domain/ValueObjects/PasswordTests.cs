using Orangotango.Business.Models.ValueObjects;
using Orangotango.Tests.Infrastructure;
using Xunit;

namespace Orangotango.Tests
{
    public class PasswordTests
    {
        [Fact]
        public void PasswordIsValid_Executed_ReturnTrue()
        {
            var scenarios = new string[]
            {
                "148.550.770-70",
                "06802626012",
                "733054.944-41",
                "016790664-04",
                "339.76734454"
            };

            foreach (var password in scenarios)
                Assert.True(Password.IsValid(password));
        }

        [Fact]
        public void PasswordIsValid_Executed_ReturnFalse()
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

            foreach (var password in scenarios)
                Assert.False(Password.IsValid(password));
        }

        [Fact]
        public void PasswordEquals_Executed_ReturnTrue()
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
