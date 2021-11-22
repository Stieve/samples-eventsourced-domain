using NCore.Infra.EventStore;
using NCore.Infra.EventStore.Abstractions;

namespace NCore.Samples.Inventory.InMemoryEventStore
{
    public class InMemoryManagedEventStoreConnectionFactory : IManagedEventStoreConnectionFactory
    {
        private readonly IEventStoreConnectionFactory _eventStoreConnectionFactory;

        public InMemoryManagedEventStoreConnectionFactory(IEventStoreConnectionFactory eventStoreConnectionFactory)
        {
            _eventStoreConnectionFactory = eventStoreConnectionFactory;
        }

        public IManagedEventStoreConnection Create()
        {
            var connection = ManagedEventStoreConnection.Create(_eventStoreConnectionFactory.Create());
            connection.ConnectAsync().GetAwaiter().GetResult();
            return connection;
        }
    }
}