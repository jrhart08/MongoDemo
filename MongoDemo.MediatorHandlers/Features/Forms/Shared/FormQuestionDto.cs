using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.Shared
{
    public class FormQuestionDto
    {
        public FormQuestionDto(Form.Question q)
        {
            ShortId = q.ShortId;
            QuestionText = q.QuestionText;
            Type = q.Type;
        }

        public string ShortId { get; set; }
        public string QuestionText { get; set; }
        public string Type { get; set; }
    }
}
