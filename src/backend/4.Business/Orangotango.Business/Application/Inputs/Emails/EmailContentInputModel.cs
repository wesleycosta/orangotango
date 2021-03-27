using System.Collections.Generic;

namespace Orangotango.Business.ViewModels.SendEmail
{
    public class EmailContentInputModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> To { get; set; }

        public EmailContentInputModel()
        {
            To = new List<string>();
        }

        public void AddEmail(string email)
        {
            To?.Add(email);
        }
    }
}
