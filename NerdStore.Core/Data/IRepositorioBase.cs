using NerdStore.Core.Domain;
using System;

namespace NerdStore.Core.Data
{
    public interface IRepositorioBase<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
