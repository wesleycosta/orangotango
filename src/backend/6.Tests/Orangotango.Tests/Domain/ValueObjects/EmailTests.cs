using Orangotango.Business.Models.ValueObjects;
using Orangotango.Core.DomainObjects;
using Xunit;

namespace Orangotango.Tests
{
    public class EmailTests
    {
        [Theory]
        [InlineData("2abd.abd@joomna.online")]
        [InlineData("2hanan-73@atulya.gq")]
        [InlineData("keimon2008p@energyce.cyou")]
        [InlineData("7ander@downhillbillies.org")]
        [InlineData("ggussyo@ciaodearborn.net")]
        public void EmailIsValid_Executed_ReturnTrue(string email)
        {
            Assert.True(Email.IsValid(email));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("tea@")]
        [InlineData("meuemail.@alfa.")]
        [InlineData("meuemail")]
        [InlineData("123@123")]
        public void EmailIsValid_Executed_ReturnFalse(string email)
        {
            Assert.False(Email.IsValid(email));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("tea@")]
        [InlineData("meuemail.@alfa.")]
        [InlineData("meuemail")]
        [InlineData("123@123")]
        public void EmailCreateWithInvalidValue_Executed_ReturnException(string cpf)
        {
            var exception = Record.Exception(() => new Password(cpf));
            Assert.NotNull(exception);
            Assert.IsType<DomainException>(exception);
        }
    }
}
