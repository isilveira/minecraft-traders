using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOffersByFilter
{
    public class GetOffersByFilterQuery : ApplicationRequest<Offer, GetOffersByFilterQueryResponse>
    {
        public GetOffersByFilterQuery()
        {
            ConfigKeys(x => x.OfferID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
