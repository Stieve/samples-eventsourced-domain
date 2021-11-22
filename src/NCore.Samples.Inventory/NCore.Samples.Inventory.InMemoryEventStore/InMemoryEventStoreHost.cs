using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace NCore.Samples.Inventory.InMemoryEventStore
{
    public class InMemoryEventStoreHost : IHostedService
    {
        private readonly IInMemoryEventStore _eventStore;

        public InMemoryEventStoreHost(IInMemoryEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _eventStore.Node.StartAsync(true);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _eventStore.Node.StopAsync(null, cancellationToken);
        }
    }
}