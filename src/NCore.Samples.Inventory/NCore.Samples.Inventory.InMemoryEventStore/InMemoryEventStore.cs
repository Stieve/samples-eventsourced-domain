using EventStore.ClientAPI.Embedded;
using EventStore.Core;

namespace NCore.Samples.Inventory.InMemoryEventStore
{
    public interface IInMemoryEventStore
    {
        ClusterVNode Node { get; }
    }

    public class InMemoryEventStore : IInMemoryEventStore
    {
        public InMemoryEventStore()
        {
            Node = EmbeddedVNodeBuilder
                .AsSingleNode()
                .OnDefaultEndpoints()
                .RunInMemory()
                .Build();
        }

        public ClusterVNode Node { get; }
    }
}