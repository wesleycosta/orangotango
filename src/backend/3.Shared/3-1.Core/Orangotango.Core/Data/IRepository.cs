using Orangotango.Core.DomainObjects;
using System;

namespace Orangotango.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}