using MediatR;
using MongoDemo.MediatorHandlers.Features.RecordedForms.Shared;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.GetRecordedForms
{
    public class GetRecordedFormsRequest : IRequest<GetRecordedFormsResponse>
    {
        public string? FormId { get; set; }
        public string? FormLinkId { get; set; }
    }

    public class GetRecordedFormsResponse
    {
        public List<RecordedFormResponseDto> RecordedForms{ get; set; }
    }
}
