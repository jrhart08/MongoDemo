using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDemo.Data;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.RecordedForms.Shared;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.GetRecordedForms
{
    public class GetRecordedFormsHandler : IRequestHandler<GetRecordedFormsRequest, GetRecordedFormsResponse>
    {
        readonly IFormsMongoClient _mongo;

        public GetRecordedFormsHandler(IFormsMongoClient mongo)
        {
            _mongo = mongo;
        }

        public async Task<GetRecordedFormsResponse> Handle(GetRecordedFormsRequest request, CancellationToken cancellationToken)
        {
            var query = await BuildQuery(request, cancellationToken);

            var recordedForms = await _mongo
                .RecordedForms()
                .Find(query)
                .ToListAsync(cancellationToken);

            return new GetRecordedFormsResponse
            {
                RecordedForms = recordedForms
                    .Select(rf => new RecordedFormResponseDto(rf))
                    .ToList(),
            };
        }

        async Task<FilterDefinition<RecordedForm>> BuildQuery(GetRecordedFormsRequest request, CancellationToken cancellationToken)
        {
            var builder = Builders<RecordedForm>.Filter;
            var query = builder.Empty;

            if (!string.IsNullOrEmpty(request.FormId))
            {
                var id = new ObjectId(request.FormId);
                
                query &= builder.Eq(rf => rf.FormId, id);
            }

            if (!string.IsNullOrEmpty(request.FormLinkId))
            {
                var formIds = await GetFormIds(request.FormLinkId, cancellationToken);

                query &= builder.In(rf => rf.FormId, formIds);
            }

            return query;
        }

        async Task<List<ObjectId>> GetFormIds(string formLinkId, CancellationToken cancellationToken)
        {
            return await _mongo
                .Forms()
                .Find(Builders<Form>.Filter.Eq(f => f.FormLinkId, formLinkId))
                .Project(form => form.Id)
                .ToListAsync(cancellationToken);
        }
    }
}
