namespace Orangotango.Core.Settings
{
    public class EmailSettings
    {
        public string From { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public static EmailSettings GetSettings()
        {
            return new EmailSettings
            {
                From = "Orangotango",
                Email = "orangotango.project@gmail.com",
                Password = "lbpebalccdepzkus",
                Host = "smtp.gmail.com",
                Port = 587
            };
        }
    }
}
