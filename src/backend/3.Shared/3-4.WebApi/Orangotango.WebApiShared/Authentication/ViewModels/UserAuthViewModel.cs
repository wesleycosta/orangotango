using System;

namespace Orangotango.WebApiShared.Authentication.ViewModels
{
    public class UserAuthViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
