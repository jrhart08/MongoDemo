using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.MediatorHandlers.Features.Root.ListDatabases
{
    public class ListDatabasesRequest : IRequest<ListDatabasesResponse>
    {

    }

    public class ListDatabasesResponse
    {
        public List<string> Databases { get; init; }
    }
}
