using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer
{
    public class PatchOfferCommand : ApplicationRequest<Offer, PatchOfferCommandResponse>
    {
        public PatchOfferCommand()
        {
            ConfigKeys(x => x.OfferID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
