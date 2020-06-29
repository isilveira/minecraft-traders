using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradeByKey
{
    public class GetTradeByKeyQueryResponse : ApplicationResponse<Trade>
    {
        public GetTradeByKeyQueryResponse()
        {
        }

        public GetTradeByKeyQueryResponse(WrapRequest<Trade> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
