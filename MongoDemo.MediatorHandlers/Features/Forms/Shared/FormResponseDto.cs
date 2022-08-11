using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.Shared
{
    public class FormResponseDto
    {
        public string Id { get; init; }
        public string FormLinkId { get; init; }
        public int Revision { get; init; }
        public string FormName { get; init; }
        public string FormType { get; init; }

        public List<FormSectionDto> Sections { get; init; }

        public FormResponseDto(Form form)
        {
            Id = form.Id.ToString();
            FormLinkId = form.FormLinkId;
            Revision = form.Revision;
            FormName = form.FormName;
            FormType = form.FormType;
            Sections = form.Sections
                .Select(s => new FormSectionDto(s))
                .ToList();
        }
    }
}
