using MediatR;
using MongoDemo.Data.Entities.Forms;
using MongoDemo.MediatorHandlers.Features.RecordedForms.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.MediatorHandlers.Features.RecordedForms.RecordForm
{
    public class RecordFormRequest : IRequest<RecordFormResponse>
    {
        public string FormId { get; set; }
        public string RecorderName { get; set; }

        public List<RecordedAnswer> Answers { get; set; }

        public class RecordedAnswer
        {
            public string Question { get; set; }
            public string Answer { get; set; }
        }
    }

    public class RecordFormResponse
    {
        public RecordedFormResponseDto RecordedForm { get; set; }
    }
}
