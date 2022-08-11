using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.Shared
{
    public class RecordedFormAnswerDto
    {
        public string Question { get; init; }
        public string Answer { get; init; }

        public RecordedFormAnswerDto(RecordedForm.Answer answer)
        {
            Question = answer.Question;
            Answer = answer.AnswerText;
        }
    }
}
