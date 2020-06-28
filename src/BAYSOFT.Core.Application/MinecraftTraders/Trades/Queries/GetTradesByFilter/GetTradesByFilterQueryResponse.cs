using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradesByFilter
{
    public class GetTradesByFilterQueryResponse : ApplicationResponse<Trade>
    {
        public GetTradesByFilterQueryResponse()
        {
        }

        public GetTradesByFilterQueryResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
