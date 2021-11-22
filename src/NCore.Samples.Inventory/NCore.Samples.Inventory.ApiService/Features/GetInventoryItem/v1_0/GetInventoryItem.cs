using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCore.Samples.Inventory.ApiService.Features.GetInventoryItem.v1_0
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class GetInventoryItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetInventoryItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInventoryItem(Guid id, CancellationToken token)
        {
            var request = new GetInventoryItem.Request { Id = id };
            var response = await _mediator.Send(request, token);
            return Ok(response);
        }
    }
}
