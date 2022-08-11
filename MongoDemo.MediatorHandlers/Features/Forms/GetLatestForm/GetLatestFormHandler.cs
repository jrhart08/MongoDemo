using MediatR;
using MongoDB.Driver;
using MongoDemo.Data;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;

namespace MongoDemo.MediatorHandlers.Features.Forms.GetLatestForm
{
    public class GetLatestFormHandler : IRequestHandler<GetLatestFormRequest, GetLatestFormResponse>
    {
        readonly IFormsMongoClient _mongo;

        public GetLatestFormHandler(IFormsMongoClient mongo)
        {
            _mongo = mongo;
        }

        public async Task<GetLatestFormResponse> Handle(GetLatestFormRequest request, CancellationToken cancellationToken)
        {
            var query = BuildQuery(request);
            var sort = GetLatestRevision();

            var form = await _mongo
                .Forms()
                .Find(query)
                .Sort(sort)
                .FirstOrDefaultAsync(cancellationToken);

            return new GetLatestFormResponse
            {
                Form = new FormResponseDto(form),
            };
        }

        static FilterDefinition<Form> BuildQuery(GetLatestFormRequest request)
        {
            var builder = Builders<Form>.Filter;

            return builder.Eq(f => f.FormLinkId, request.FormLinkId);
        }

        static SortDefinition<Form> GetLatestRevision()
        {
            var builder = Builders<Form>.Sort;
            
            return builder.Descending(form => form.Revision);
        }
    }
}
