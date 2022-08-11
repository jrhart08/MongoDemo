using MediatR;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;

namespace MongoDemo.MediatorHandlers.Features.Forms.GetForms
{
    public class GetFormsRequest : IRequest<GetFormsResponse>
    {
        public string? FormType { get; init; }
        public string? FormLinkId { get; init; }
    }
    
    public class GetFormsResponse
    {
        public List<FormResponseDto> Forms { get; init; }

    }
}
