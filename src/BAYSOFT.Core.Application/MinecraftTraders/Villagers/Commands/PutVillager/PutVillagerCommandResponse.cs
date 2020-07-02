using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PutVillager
{
    public class PutVillagerCommandResponse : ApplicationResponse<Villager>
    {
        public PutVillagerCommandResponse()
        {
        }

        public PutVillagerCommandResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
