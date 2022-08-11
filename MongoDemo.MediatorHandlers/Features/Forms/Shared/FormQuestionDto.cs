using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.Shared
{
    public class FormQuestionDto
    {
        public FormQuestionDto(Form.Question q)
        {
            QuestionText = q.QuestionText;
            Type = q.Type;
        }

        public string QuestionText { get; set; }
        public string Type { get; set; }
    }
}
