using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PutTrade
{
    public class PutTradeCommandResponse : ApplicationResponse<Trade>
    {
        public PutTradeCommandResponse()
        {
        }

        public PutTradeCommandResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
