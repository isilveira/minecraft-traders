using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer
{
    public class PatchOfferCommandResponse : ApplicationResponse<Offer>
    {
        public PatchOfferCommandResponse()
        {
        }

        public PatchOfferCommandResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
