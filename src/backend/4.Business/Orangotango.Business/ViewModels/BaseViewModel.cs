using System;

namespace Orangotango.Business.ViewModels
{
    public abstract class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Active { get; set; }
    }
}
