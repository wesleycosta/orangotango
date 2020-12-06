using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Business.Models
{
    public class TimeLine : Entity
    {
        public DateTime Date { get; set; }
        public string Replica { get; set; }

        public Guid IdApplication { get; set; }
        public Application Application { get; set; }
    }
}
