using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOfferByKey
{
    public class GetOfferByKeyQuery : ApplicationRequest<Offer, GetOfferByKeyQueryResponse>
    {
        public GetOfferByKeyQuery()
        {
            ConfigKeys(x => x.OfferID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
