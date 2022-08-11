using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.Shared
{
    public class FormSectionDto
    {
        public string SectionName { get; set; }
        public List<FormQuestionDto> Questions { get; set; }

        public FormSectionDto(Form.Section formSection)
        {
            SectionName = formSection.SectionName;
            Questions = formSection
                .Questions
                .Select(q => new FormQuestionDto(q))
                .ToList();
        }
    }
}
