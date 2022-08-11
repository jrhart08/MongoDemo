using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.Shared
{
    public class RecordedFormResponseDto
    {
        public string FormId { get; init; }
        public string RecorderName { get; init; }
        public bool IsDeleted { get; init; }
        public List<RecordedFormAnswerDto> Answers { get; init; }

        public RecordedFormResponseDto(RecordedForm rf)
        {
            FormId = rf.FormId.ToString();
            RecorderName = rf.RecorderName;
            IsDeleted = rf.IsDeleted;

            Answers = rf.Answers
                .Select(a => new RecordedFormAnswerDto(a))
                .ToList();
        }
    }
}
