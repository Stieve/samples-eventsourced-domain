using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCore.Samples.Inventory.ApiService.Features.ActivateIntentoryItem.v1_0
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class ActivateInventoryItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivateInventoryItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> ActivateAsync(Guid id, CancellationToken token)
        {
            var request = new ActivateInventoryItem.Request { Id = id };
            var response = await _mediator.Send(request, token);
            return NoContent();
        }
    }
}
