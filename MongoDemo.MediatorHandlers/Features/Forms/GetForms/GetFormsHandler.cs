using MediatR;
using MongoDB.Driver;
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
            var query = BuildQuery(request);

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

        static FilterDefinition<Form> BuildQuery(GetFormsRequest request)
        {
            var builder = Builders<Form>.Filter;
            var query = builder.Empty;

            if (!string.IsNullOrEmpty(request.FormType))
            {
                query &= builder.Eq(f => f.FormType, request.FormType);
            }

            if (!string.IsNullOrEmpty(request.FormLinkId))
            {
                query &= builder.Eq(f => f.FormLinkId, request.FormLinkId);
            }

            return query;
        }
    }
}
