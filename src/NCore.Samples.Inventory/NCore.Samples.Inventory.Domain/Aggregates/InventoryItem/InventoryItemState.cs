using NCore.Patterns.Domain;
using NCore.Patterns.Domain.Abstractions;

namespace NCore.Samples.Inventory.Domain.Aggregates.InventoryItem
{
    public class InventoryItemState : State
    {
        public InventoryItemState(IEventEmitter eventEmitter)
            : base(eventEmitter)
        {
        }

        protected override void RegisterHandlers()
        {
            On<Events.v1.InventoryItemCreatedEvent>(@event =>
            {
                State = InventoryItemStateType.Draft;
                Name = @event.Name;
                Description = @event.Description;
            });
            On<Events.v1.InventoryItemActivatedEvent>(@event =>
            {
                State = InventoryItemStateType.Active;
            });
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public InventoryItemStateType State { get; private set; } = InventoryItemStateType.New;
    }

    public enum InventoryItemStateType
    {
        New,
        Draft,
        Active,
    }
}