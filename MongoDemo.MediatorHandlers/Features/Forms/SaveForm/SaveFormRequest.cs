using MediatR;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;
using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.SaveForm
{
    public class SaveFormRequest : IRequest<SaveFormResponse>
    {
        /// <summary>
        /// If blank, will generate a new FormLinkId.
        /// Otherwise, will create this as a new revision
        /// </summary>
        public string? FormLinkId { get; init; }
        public string FormName { get; init; }
        public string FormType { get; init; }
        public List<Form.Section> Sections { get; init; }
    }

    public class SaveFormResponse
    {
        public FormResponseDto SavedForm { get; init; }
    }
}
