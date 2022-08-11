using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDemo.MediatorHandlers.Features.Forms.GetForms;
using MongoDemo.MediatorHandlers.Features.Forms.GetLatestForm;
using MongoDemo.MediatorHandlers.Features.Root.ListDatabases;
using System.Threading.Tasks;

namespace MongoDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        readonly IMediator _mediator;

        public MongoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("databases")]
        public async Task<ListDatabasesResponse> ListDatabases()
            => await _mediator.Send(new ListDatabasesRequest());

        [HttpGet("forms")]
        public async Task<GetFormsResponse> GetForms([FromQuery] GetFormsRequest request)
            => await _mediator.Send(request);

        [HttpGet("forms/{FormLinkId}/latest")]
        public async Task<GetLatestFormResponse> GetLatestForm([FromRoute] GetLatestFormRequest request)
            => await _mediator.Send(request);
    }
}
