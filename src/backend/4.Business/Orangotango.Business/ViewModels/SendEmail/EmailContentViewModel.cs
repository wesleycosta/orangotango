using System.Collections.Generic;

namespace Orangotango.Business.ViewModels.SendEmail
{
    public class EmailContentViewModel
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailContentViewModel()
        {
            To = new List<string>();
        }

        public void AddEmail(string email)
        {
            To?.Add(email);
        }
    }
}
