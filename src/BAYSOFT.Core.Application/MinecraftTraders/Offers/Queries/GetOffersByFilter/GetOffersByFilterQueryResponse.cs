using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOffersByFilter
{
    public class GetOffersByFilterQueryResponse : ApplicationResponse<Offer>
    {
        public GetOffersByFilterQueryResponse()
        {
        }

        public GetOffersByFilterQueryResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
