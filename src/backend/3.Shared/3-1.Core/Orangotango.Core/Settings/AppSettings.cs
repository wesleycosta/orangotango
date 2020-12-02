namespace Orangotango.Core.Settings
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public EnvironmentType Environment { get; set; }
        public JwtSettings JwtSettings { get; set; }
    }
}
