using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer
{
    public class PutOfferCommandResponse : ApplicationResponse<Offer>
    {
        public PutOfferCommandResponse()
        {
        }

        public PutOfferCommandResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
