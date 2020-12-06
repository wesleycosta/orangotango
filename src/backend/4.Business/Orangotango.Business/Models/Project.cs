using Orangotango.Core.DomainObjects;
using System.Collections.Generic;

namespace Orangotango.Business.Models
{
    public class Project : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Application> Applications { get; set; }
    }
}
