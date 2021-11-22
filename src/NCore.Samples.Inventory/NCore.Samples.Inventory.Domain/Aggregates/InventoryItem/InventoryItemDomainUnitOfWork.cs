using System;
using NCore.Patterns.Domain.Abstractions;
using NCore.Patterns.Domain.EventStore;

namespace NCore.Samples.Inventory.Domain.Aggregates.InventoryItem
{
    public class InventoryItemDomainUnitOfWork : EventStoreDomainUnitOfWork<InventoryItemAggregate>, IInventoryItemDomainUnitOfWork
    {
        public InventoryItemDomainUnitOfWork(IEventSourcedRepository eventSourcedRepository, IServiceProvider serviceProvider) 
            : base(eventSourcedRepository, serviceProvider)
        {
        }
    }

    public interface IInventoryItemDomainUnitOfWork : IDomainUnitOfWork<InventoryItemAggregate>
    {
    }
}