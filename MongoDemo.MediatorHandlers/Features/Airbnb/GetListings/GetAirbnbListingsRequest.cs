using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDemo.MediatorHandlers.Features.Airbnb.GetListings
{
    public class GetAirbnbListingsRequest : IRequest<GetAirbnbListingsResponse>
    {
        public string? Country { get; init; }
        public int? MinRating { get; init; }
    }

    public class GetAirbnbListingsResponse
    {

    }
}
