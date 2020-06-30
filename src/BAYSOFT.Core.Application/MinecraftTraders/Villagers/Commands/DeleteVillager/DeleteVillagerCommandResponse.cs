using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.DeleteVillager
{
    public class DeleteVillagerCommandResponse : ApplicationResponse<Villager>
    {
        public DeleteVillagerCommandResponse()
        {
        }

        public DeleteVillagerCommandResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
