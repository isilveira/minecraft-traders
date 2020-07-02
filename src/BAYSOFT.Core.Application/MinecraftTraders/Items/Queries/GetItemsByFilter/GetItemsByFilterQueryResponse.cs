using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemsByFilter
{
    public class GetItemsByFilterQueryResponse : ApplicationResponse<Item>
    {
        public GetItemsByFilterQueryResponse()
        {
        }

        public GetItemsByFilterQueryResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
