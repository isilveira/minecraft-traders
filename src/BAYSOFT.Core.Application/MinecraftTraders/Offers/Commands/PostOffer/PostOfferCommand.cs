using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PostOffer
{
    public class PostOfferCommand : ApplicationRequest<Offer, PostOfferCommandResponse>
    {
        public PostOfferCommand()
        {
            ConfigKeys(x => x.OfferID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
