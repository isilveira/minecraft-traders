using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer
{
    public class PutOfferCommand : ApplicationRequest<Offer, PutOfferCommandResponse>
    {
        public PutOfferCommand()
        {
            ConfigKeys(x => x.OfferID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
