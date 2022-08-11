using MediatR;
using MongoDB.Driver;
using MongoDemo.Data;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;

namespace MongoDemo.MediatorHandlers.Features.Forms.SaveForm
{
    public class SaveFormHandler : IRequestHandler<SaveFormRequest, SaveFormResponse>
    {
        readonly IFormsMongoClient _mongo;

        public SaveFormHandler(IFormsMongoClient mongo)
        {
            _mongo = mongo;
        }

        public async Task<SaveFormResponse> Handle(SaveFormRequest request, CancellationToken cancellationToken)
        {
            var (revision, formLinkId) = await GetNextRevision(request, cancellationToken);

            var newform = new Form
            {
                // similar to EF, we leave the Id empty and let IMongoClient generate it
                FormName = request.FormName,
                FormType = request.FormType,
                Sections = request.Sections,
                Revision = revision,
                FormLinkId = formLinkId,
            };

            await _mongo.Forms().InsertOneAsync(newform, null, cancellationToken);

            return new SaveFormResponse
            {
                SavedForm = new FormResponseDto(newform),
            };
        }

        async Task<(int, string)> GetNextRevision(SaveFormRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.FormLinkId))
            {
                var formLinkId = Guid.NewGuid().ToString();

                return (1, formLinkId);
            }

            var existingCount = await _mongo
                .Forms()
                .Find(Builders<Form>.Filter.Eq(f => f.FormLinkId, request.FormLinkId))
                .CountDocumentsAsync(cancellationToken);

            var revision = (int)existingCount + 1;

            return (revision, request.FormLinkId);
        }
    }
}
