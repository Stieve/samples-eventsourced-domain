using Mono.Posix;
using NCore.Patterns.Domain;
using NCore.Patterns.Domain.Abstractions;
using NCore.Patterns.Domain.EventStore.Serialization;
using NCore.Samples.Inventory.Domain.Aggregates.InventoryItem.Exceptions;

namespace NCore.Samples.Inventory.Domain.Aggregates.InventoryItem
{
    public class InventoryItemAggregate : Aggregate<InventoryItemState>
    {
        public InventoryItemAggregate(string key, InventoryItemState state, IEventEmitter eventEmitter)
            : base(key, state, eventEmitter)
        {
        }

        public void Create(string name, string description)
        {
            if (State.State != InventoryItemStateType.New)
                throw new InventoryItemAlreadyExistsException(Key);

            var @event = new Events.v1.InventoryItemCreatedEvent
            {
                Name = name,
                Description = description
            };

            Handle(@event);
        }

        public void Activate()
        {
            if (State.State != InventoryItemStateType.Draft)
                throw new InventoryItemCannotBeActivatedException(Key, State.State.ToString());

            var @event = new Events.v1.InventoryItemActivatedEvent();
            Handle(@event);
        }

        public string GetName() => State.Name;
        public string GetDescription() => State.Description;
        public string GetState() => State.State.ToString();
    }
}