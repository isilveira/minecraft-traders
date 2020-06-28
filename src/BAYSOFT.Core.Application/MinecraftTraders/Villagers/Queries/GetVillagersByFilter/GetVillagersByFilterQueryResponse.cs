using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagersByFilter
{
    public class GetVillagersByFilterQueryResponse : ApplicationResponse<Villager>
    {
        public GetVillagersByFilterQueryResponse()
        {
        }

        public GetVillagersByFilterQueryResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
