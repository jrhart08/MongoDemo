using MediatR;
using MongoDB.Bson;
using MongoDemo.Data;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.RecordedForms.Shared;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.RecordForm
{
    public class RecordFormHandler : IRequestHandler<RecordFormRequest, RecordFormResponse>
    {
        readonly IFormsMongoClient _mongo;

        public RecordFormHandler(IFormsMongoClient mongo)
        {
            _mongo = mongo;
        }

        public async Task<RecordFormResponse> Handle(RecordFormRequest request, CancellationToken cancellationToken)
        {
            var recordedForm = ToRecordedForm(request);;

            await _mongo.RecordedForms().InsertOneAsync(recordedForm, null, cancellationToken);

            return new RecordFormResponse
            {
                RecordedForm = new RecordedFormResponseDto(recordedForm),
            };
        }

        private RecordedForm ToRecordedForm(RecordFormRequest request)
        {
            var answers = request.Answers
                .Select(a => new RecordedForm.Answer
                {
                    QuestionId = a.QuestionId,
                    AnswerText = a.Answer,
                })
                .ToList();

            return new RecordedForm
            {
                FormId = new ObjectId(request.FormId),
                RecorderName = request.RecorderName,
                Answers = answers,
            };
        }
    }
}
