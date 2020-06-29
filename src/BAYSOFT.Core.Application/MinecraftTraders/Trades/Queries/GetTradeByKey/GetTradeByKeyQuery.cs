using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradeByKey
{
    public class GetTradeByKeyQuery : ApplicationRequest<Trade, GetTradeByKeyQueryResponse>
    {
        public GetTradeByKeyQuery()
        {
            ConfigKeys(x => x.TradeID);

            ConfigSuppressedProperties(x => x.Villager);
            ConfigSuppressedProperties(x => x.Accepts);
            ConfigSuppressedProperties(x => x.Offers);

            ConfigSuppressedResponseProperties(x => x.Villager);
            ConfigSuppressedResponseProperties(x => x.Accepts);
            ConfigSuppressedResponseProperties(x => x.Offers);
        }
    }
}
