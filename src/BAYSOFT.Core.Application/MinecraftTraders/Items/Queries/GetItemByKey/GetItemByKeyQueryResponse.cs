using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemByKey
{
    public class GetItemByKeyQueryResponse : ApplicationResponse<Item>
    {
        public GetItemByKeyQueryResponse()
        {
        }

        public GetItemByKeyQueryResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
