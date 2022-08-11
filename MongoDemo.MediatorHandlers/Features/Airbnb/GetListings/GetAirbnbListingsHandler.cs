using MediatR;
using MongoDB.Driver;
using MongoDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.MediatorHandlers.Features.Airbnb.GetListings
{
    internal class GetAirbnbListingsHandler : IRequestHandler<GetAirbnbListingsRequest, GetAirbnbListingsResponse>
    {
        readonly IFormsMongoClient _mongo;

        public GetAirbnbListingsHandler(IFormsMongoClient mongo)
        {
            _mongo = mongo;
        }

        public Task<GetAirbnbListingsResponse> Handle(GetAirbnbListingsRequest request, CancellationToken cancellationToken)
        {
            var collection = _mongo.GetDatabase(Databases.Airbnb);

            throw new NotImplementedException();
        }
    }
}
