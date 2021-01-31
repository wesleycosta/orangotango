namespace Orangotango.Core.Settings
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }
        public string DataBase { get; set; }
        public EnvironmentType Environment { get; set; }
        public string Origins { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public LoggerSettings LoggerSettings { get; set; }

        public string[] GetOrigns()
        {
            if (string.IsNullOrEmpty(Origins))
                return null;

            return Origins.Split(';');
        }
    }
}
