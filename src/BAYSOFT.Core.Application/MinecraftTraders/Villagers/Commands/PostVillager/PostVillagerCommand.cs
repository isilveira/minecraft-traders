using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PostVillager
{
    public class PostVillagerCommand : ApplicationRequest<Villager, PostVillagerCommandResponse>
    {
        public PostVillagerCommand()
        {
            ConfigKeys(x => x.VillagerID);

            ConfigSuppressedProperties(x => x.Profession);
            ConfigSuppressedProperties(x => x.Trades);

            ConfigSuppressedResponseProperties(x => x.Profession);
            ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
