using System.Text;

namespace Orangotango.Core.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Hours { get; set; }

        public byte[] Key => Encoding.ASCII.GetBytes(Secret);
    }
}
