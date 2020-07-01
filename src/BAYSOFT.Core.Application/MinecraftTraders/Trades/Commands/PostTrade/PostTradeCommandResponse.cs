using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PostTrade
{
    public class PostTradeCommandResponse : ApplicationResponse<Trade>
    {
        public PostTradeCommandResponse()
        {
        }

        public PostTradeCommandResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
