using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PatchTrade
{
    public class PatchTradeCommandResponse : ApplicationResponse<Trade>
    {
        public PatchTradeCommandResponse()
        {
        }

        public PatchTradeCommandResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
