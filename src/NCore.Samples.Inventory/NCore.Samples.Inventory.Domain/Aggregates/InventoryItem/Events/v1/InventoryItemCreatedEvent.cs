using NCore.Patterns.Domain.Abstractions;

namespace NCore.Samples.Inventory.Domain.Aggregates.InventoryItem.Events.v1
{
    public class InventoryItemCreatedEvent : IDomainEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
