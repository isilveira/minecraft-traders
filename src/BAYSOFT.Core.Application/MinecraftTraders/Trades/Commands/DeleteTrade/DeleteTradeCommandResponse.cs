using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.DeleteTrade
{
    public class DeleteTradeCommandResponse : ApplicationResponse<Trade>
    {
        public DeleteTradeCommandResponse()
        {
        }

        public DeleteTradeCommandResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
