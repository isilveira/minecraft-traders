using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PatchVillager
{
    public class PatchVillagerCommandResponse : ApplicationResponse<Villager>
    {
        public PatchVillagerCommandResponse()
        {
        }

        public PatchVillagerCommandResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
