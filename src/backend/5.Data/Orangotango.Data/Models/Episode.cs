using System;

namespace Orangotango.Data.Models
{
    public class Episode : Entity
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Sinopse { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
