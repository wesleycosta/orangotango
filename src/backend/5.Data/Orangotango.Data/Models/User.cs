using System;

namespace Orangotango.Data.Models
{
    public class User : Entity
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public UserGenderType Gender { get; set; }
    }
}
