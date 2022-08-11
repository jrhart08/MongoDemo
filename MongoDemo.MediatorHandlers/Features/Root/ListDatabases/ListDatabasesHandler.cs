using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDemo.Data;

namespace MongoDemo.MediatorHandlers.Features.Root.ListDatabases
{
    public class ListDatabasesHandler : IRequestHandler<ListDatabasesRequest, ListDatabasesResponse>
    {
        readonly IFormsMongoClient _mongo;

        public ListDatabasesHandler(IFormsMongoClient mongoClient)
        {
            _mongo = mongoClient;
        }

        public async Task<ListDatabasesResponse> Handle(ListDatabasesRequest request, CancellationToken cancellationToken)
        {
            List<BsonDocument> databases = await _mongo
                .ListDatabases()
                .ToListAsync(cancellationToken);

            var dbStrings = databases
                .Select(db => db.ToString())
                .ToList();

            return new ListDatabasesResponse
            {
                Databases = dbStrings,
            };
        }
    }
}
