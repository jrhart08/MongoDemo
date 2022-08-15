using MediatR;
using MongoDemo.MediatorHandlers.Features.RecordedForms.Shared;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.RecordForm
{
    public class RecordFormRequest : IRequest<RecordFormResponse>
    {
        public string FormId { get; set; }
        public string RecorderName { get; set; }

        public List<RecordedAnswer> Answers { get; set; }

        public class RecordedAnswer
        {
            public string QuestionId { get; set; }
            public string Answer { get; set; }
        }
    }

    public class RecordFormResponse
    {
        public RecordedFormResponseDto RecordedForm { get; set; }
    }
}
