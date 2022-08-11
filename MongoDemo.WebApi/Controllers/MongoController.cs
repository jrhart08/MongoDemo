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
    }
}
