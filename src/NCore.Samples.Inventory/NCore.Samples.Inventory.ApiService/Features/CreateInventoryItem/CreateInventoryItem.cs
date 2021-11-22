using System;
using System.Threading;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using MediatR;
using NCore.Samples.Inventory.Domain.Aggregates.InventoryItem;
using NCore.Samples.Inventory.Domain.Infra;

namespace NCore.Samples.Inventory.ApiService.Features.CreateInventoryItem
{
    public static class CreateInventoryItem
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Response
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Request, Response>
        {
            private readonly IInventoryItemDomainUnitOfWork _unitOfWork;

            public Handler(IInventoryItemDomainUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var aggregate = await _unitOfWork.GetAsync<InventoryItemState>(request.Id.AsAggregateKey(), cancellationToken);
                aggregate.Create(request.Name, request.Description);
                await _unitOfWork.CommitAsync(ExpectedVersion.NoStream, cancellationToken);
                return new Response { Id = request.Id };
            }
        }
    }
}
