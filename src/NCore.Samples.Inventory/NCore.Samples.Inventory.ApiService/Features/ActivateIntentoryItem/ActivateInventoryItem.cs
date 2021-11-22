using System;
using System.Threading;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using MediatR;
using NCore.Samples.Inventory.Domain.Aggregates.InventoryItem;
using NCore.Samples.Inventory.Domain.Infra;

namespace NCore.Samples.Inventory.ApiService.Features.ActivateIntentoryItem
{
    public static class ActivateInventoryItem
    {
        public class Request : IRequest<Response>
        {
            public Guid Id { get; set; }
        }

        public class Response
        {
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
                aggregate.Activate();
                await _unitOfWork.CommitAsync(ExpectedVersion.StreamExists, cancellationToken);
                return new Response();
            }
        }
    }
}
