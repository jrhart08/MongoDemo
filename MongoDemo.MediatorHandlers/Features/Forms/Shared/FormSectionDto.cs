﻿using MongoDemo.Data.Entities.Forms;

namespace MongoDemo.MediatorHandlers.Features.Forms.Shared
{
    public class FormSectionDto
    {
        public string ShortId { get; set; }
        public string SectionName { get; set; }
        public List<FormQuestionDto> Questions { get; set; }

        public FormSectionDto(Form.Section formSection)
        {
            ShortId = formSection.ShortId;
            SectionName = formSection.SectionName;
            Questions = formSection
                .Questions
                .Select(q => new FormQuestionDto(q))
                .ToList();
        }
    }
}
