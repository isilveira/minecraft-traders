using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PostVillager
{
    public class PostVillagerCommandResponse : ApplicationResponse<Villager>
    {
        public PostVillagerCommandResponse()
        {
        }

        public PostVillagerCommandResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
