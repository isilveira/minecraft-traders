using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagerByKey
{
    public class GetVillagerByKeyQueryResponse : ApplicationResponse<Villager>
    {
        public GetVillagerByKeyQueryResponse()
        {
        }

        public GetVillagerByKeyQueryResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
