using MediatR;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;

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
        public List<SaveSectionRequest> Sections { get; init; }

        public class SaveSectionRequest
        {
            public string SectionName { get; init; }
            public List<SaveQuestionRequest> Questions { get; init; }
        }

        public class SaveQuestionRequest
        {
            public string QuestionText { get; init; }
            public string QuestionType { get; init; }
        }
    }

    public class SaveFormResponse
    {
        public FormResponseDto SavedForm { get; init; }
    }
}
