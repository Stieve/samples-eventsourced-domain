using Microsoft.Extensions.DependencyInjection;
using NCore.Patterns.Domain;
using NCore.Patterns.Domain.Abstractions;
using NCore.Patterns.Domain.EventStore;
using NCore.Patterns.Domain.EventStore.Abstractions;
using NCore.Patterns.Domain.EventStore.Serialization;
using NCore.Samples.Inventory.Domain.Aggregates.InventoryItem;
using NCore.Samples.Inventory.InMemoryEventStore;

namespace NCore.Samples.Inventory.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInventoryDomain(this IServiceCollection services)
        {
            services.AddNCoreDomainEventStore(options => { });

            //Only necessary when using in memory eventstore
            services.AddInMemoryEventStore();

            services.AddScoped<IEventSourcedRepository, EventSourcedRepository>();
            services.AddSingleton<IDomainEventSerializer, DefaultDomainEventSerializer>();
            services.AddScoped<IEventEmitter, DefaultEventEmitter>();
            services.AddScoped<IInventoryItemDomainUnitOfWork, InventoryItemDomainUnitOfWork>();
            return services;
        }
    }
}
