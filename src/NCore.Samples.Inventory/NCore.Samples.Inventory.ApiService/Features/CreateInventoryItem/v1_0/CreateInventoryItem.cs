using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NCore.Samples.Inventory.ApiService.Features.CreateInventoryItem.v1_0
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class CreateInventoryItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateInventoryItemController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateInventoryItem(CreateInventoryItemModel model, CancellationToken token)
        {
            var request = _mapper.Map<CreateInventoryItem.Request>(model);
            var response = await _mediator.Send(request, token);

            return CreatedAtAction("GetInventoryItem", "GetInventoryItem", new { version = "1", id = response.Id }, new { response.Id });
        }
    }

    public class CreateInventoryItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateInventoryItemMapperProfile : Profile
    {
        public CreateInventoryItemMapperProfile()
        {
            CreateMap<CreateInventoryItemModel, CreateInventoryItem.Request>();
        }
    }
}
