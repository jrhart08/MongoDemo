using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDemo.MediatorHandlers.Features.Forms.GetForms;
using MongoDemo.MediatorHandlers.Features.Forms.GetLatestForm;
using MongoDemo.MediatorHandlers.Features.Forms.SaveForm;
using System.Threading.Tasks;

namespace MongoDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        readonly IMediator _mediator;

        public FormsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("")]
        public async Task<GetFormsResponse> GetForms([FromQuery] GetFormsRequest request)
            => await _mediator.Send(request);

        [HttpGet("{FormLinkId}/latest")]
        public async Task<GetLatestFormResponse> GetLatestForm([FromRoute] GetLatestFormRequest request)
            => await _mediator.Send(request);

        [HttpPost("")]
        public async Task<SaveFormResponse> SaveForm([FromBody] SaveFormRequest request)
            => await _mediator.Send(request);
    }
}
