using System;

namespace Orangotango.Core.Authentication.Models
{
    public class UserAuthViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
