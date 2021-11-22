using EventStore.ClientAPI;
using EventStore.ClientAPI.Embedded;
using NCore.Infra.EventStore.Abstractions;

namespace NCore.Samples.Inventory.InMemoryEventStore
{
    public class InMemoryEventStoreConnectionFactory : IEventStoreConnectionFactory
    {
        private readonly IInMemoryEventStore _inMemoryEventStore;

        public InMemoryEventStoreConnectionFactory(IInMemoryEventStore inMemoryEventStore)
        {
            _inMemoryEventStore = inMemoryEventStore;
        }

        public IEventStoreConnection Create()
        {
            return EmbeddedEventStoreConnection.Create(_inMemoryEventStore.Node);
        }
    }
}