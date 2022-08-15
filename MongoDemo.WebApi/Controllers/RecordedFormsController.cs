using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDemo.MediatorHandlers.Features.RecordedForms.GetRecordedForms;
using MongoDemo.MediatorHandlers.Features.RecordedForms.RecordForm;
using System.Threading.Tasks;

namespace MongoDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordedFormsController : ControllerBase
    {
        readonly IMediator _mediator;

        public RecordedFormsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<GetRecordedFormsResponse> GetRecordedForms([FromQuery] GetRecordedFormsRequest request)
            => await _mediator.Send(request);

        [HttpPost("")]
        public async Task<RecordFormResponse> RecordForm([FromBody] RecordFormRequest request)
            => await _mediator.Send(request);
    }
}
