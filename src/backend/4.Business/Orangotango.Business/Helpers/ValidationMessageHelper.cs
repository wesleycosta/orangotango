namespace Orangotango.Business.Helpers
{
    public static class ValidationMessageHelper
    {
        public static string NotInformed(string field)
        {
            return $"O campo {field} não foi informado";
        }

        public static string IsInvalid(string field)
        {
            return $"O campo {field} é inválido";
        }

        public static string IdentifierIsInvalid()
        {
            return "O campo id é inválido";
        }
    }
}
