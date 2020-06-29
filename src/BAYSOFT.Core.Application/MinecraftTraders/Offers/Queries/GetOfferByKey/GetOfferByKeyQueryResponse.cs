using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOfferByKey
{
    public class GetOfferByKeyQueryResponse : ApplicationResponse<Offer>
    {
        public GetOfferByKeyQueryResponse()
        {
        }

        public GetOfferByKeyQueryResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
