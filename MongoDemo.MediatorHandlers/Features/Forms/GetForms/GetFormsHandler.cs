using MediatR;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;
using MongoDemo.Data;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;

namespace MongoDemo.MediatorHandlers.Features.Forms.GetForms
{
    public class GetFormsHandler : IRequestHandler<GetFormsRequest, GetFormsResponse>
    {
        readonly IFormsMongoClient _mongo;

        public GetFormsHandler(IFormsMongoClient client)
        {
            _mongo = client;
        }

        public async Task<GetFormsResponse> Handle(GetFormsRequest request, CancellationToken cancellationToken)
        {
            var query = await BuildQuery(request);

            List<Form> forms = await _mongo
                .Forms()
                .Find(query)
                .ToListAsync(cancellationToken);

            return new GetFormsResponse
            {
                Forms = forms
                    .Select(form => new FormResponseDto(form))
                    .ToList(),
            };
        }

        async Task<FilterDefinition<Form>> BuildQuery(GetFormsRequest request)
        {
            var builder = Builders<Form>.Filter;
            FilterDefinition<Form> query = builder.Empty;

            if (!string.IsNullOrEmpty(request.FormType))
            {
                query &= builder.Eq(f => f.FormType, request.FormType);
            }

            if (!string.IsNullOrEmpty(request.FormLinkId))
            {
                query &= builder.Eq(f => f.FormLinkId, request.FormLinkId);
            }

            if (request.Latest)
            {
                List<ObjectId> latestFormIds = await GetLatestFormsPerLinkId();

                query &= builder.In(f => f.Id, latestFormIds);
            }

            return query;
        }

        async Task<List<ObjectId>> GetLatestFormsPerLinkId()
        {
            var latestFormIdResults = await _mongo
                .Forms()
                .Aggregate(new BsonDocumentStagePipelineDefinition<Form, BsonDocument>(new[]
                {
                    new BsonDocument("$sort", new BsonDocument
                    {
                        { "formLinkId", 1 },
                        { "revision", -1 }
                    }),
                    new BsonDocument("$group", new BsonDocument
                    {
                        { "_id", "$formLinkId" },
                        { "latestFormId", new BsonDocument("$first", "$_id") }
                    })
                }))
                .ToListAsync();

            return latestFormIdResults
                .Select(x => x.GetElement("latestFormId").Value.AsObjectId)
                .ToList();
        }
    }
}
