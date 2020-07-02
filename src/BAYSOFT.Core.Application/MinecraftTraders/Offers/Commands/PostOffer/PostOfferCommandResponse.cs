using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PostOffer
{
    public class PostOfferCommandResponse : ApplicationResponse<Offer>
    {
        public PostOfferCommandResponse()
        {
        }

        public PostOfferCommandResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
