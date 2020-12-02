using System;

namespace Orangotango.Business.Models
{
    public class Application : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationType Type { get; set; }
        public TimeSpan Lifetime { get; set; }

        public Project Project { get; set; }
        public Guid IdProject { get; set; }
    }
}
