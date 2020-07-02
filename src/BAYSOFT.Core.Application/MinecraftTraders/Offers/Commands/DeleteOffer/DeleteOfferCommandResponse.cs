using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommandResponse : ApplicationResponse<Offer>
    {
        public DeleteOfferCommandResponse()
        {
        }

        public DeleteOfferCommandResponse(WrapRequest<Offer> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
