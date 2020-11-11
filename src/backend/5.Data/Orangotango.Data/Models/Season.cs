using System;

namespace Orangotango.Data.Models
{
    public class Season : Entity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime Premieres { get; set; }
        public DateTime Completion { get; set; }
    }
}
