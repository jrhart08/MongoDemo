using MediatR;
using MongoDemo.MediatorHandlers.Features.Forms.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.MediatorHandlers.Features.Forms.GetLatestForm
{
    public class GetLatestFormRequest : IRequest<GetLatestFormResponse>
    {
        public string FormLinkId { get; init; }
    }

    public class GetLatestFormResponse
    {
        public FormResponseDto Form { get; set; }
    }
}
