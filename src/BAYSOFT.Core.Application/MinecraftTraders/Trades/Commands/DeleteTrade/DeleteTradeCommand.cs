using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.DeleteTrade
{
    public class DeleteTradeCommand : ApplicationRequest<Trade, DeleteTradeCommandResponse>
    {
        public DeleteTradeCommand()
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
