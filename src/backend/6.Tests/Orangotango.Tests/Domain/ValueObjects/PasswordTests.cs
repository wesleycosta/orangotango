using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;
using Xunit;

namespace Orangotango.Tests
{
    public class PasswordTests
    {
        [Theory]
        [InlineData("@StarWars5")]
        [InlineData("Password@123")]
        [InlineData("MinhaSenha!00")]
        [InlineData("Marvel@2020")]
        [InlineData("@HellBl4zer!")]
        public void PasswordIsValid_Executed_ReturnTrue(string password)
        {
            Assert.True(Password.IsValid(password));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123456")]
        [InlineData("mi@nhasenha")]
        [InlineData("nova.senha")]
        [InlineData("123@123")]
        public void PasswordIsValid_Executed_ReturnFalse(string password)
        {
            Assert.False(Password.IsValid(password));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("123456")]
        [InlineData("mi@nhasenha")]
        [InlineData("nova.senha")]
        [InlineData("123@123")]
        public void PasswordCreateWithInvalidValue_Executed_ReturnException(string cpf)
        {
            var exception = Record.Exception(() => new Password(cpf));
            Assert.NotNull(exception);
            Assert.IsType<DomainException>(exception);
        }
    }
}
