using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PostTrade
{
    public class PostTradeCommand : ApplicationRequest<Trade, PostTradeCommandResponse>
    {
        public PostTradeCommand()
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
