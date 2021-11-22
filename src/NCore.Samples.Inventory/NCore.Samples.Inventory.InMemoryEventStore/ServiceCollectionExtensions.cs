using Microsoft.Extensions.DependencyInjection;
using NCore.Infra.EventStore.Abstractions;

namespace NCore.Samples.Inventory.InMemoryEventStore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryEventStore(this IServiceCollection services)
        {
            services.AddSingleton<IInMemoryEventStore, InMemoryEventStore>();
            services.AddHostedService<InMemoryEventStoreHost>();
            //Overwrite the default ManagedEventStoreConnectionFactory
            services.AddSingleton<IManagedEventStoreConnectionFactory, InMemoryManagedEventStoreConnectionFactory>();
            //overwrite the default EventStoreConnectionFactory
            services.AddSingleton<IEventStoreConnectionFactory, InMemoryEventStoreConnectionFactory>();
            return services;
        }
    }
}
