using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PatchVillager
{
    public class PatchVillagerCommand : ApplicationRequest<Villager, PatchVillagerCommandResponse>
    {
        public PatchVillagerCommand()
        {
            ConfigKeys(x => x.VillagerID);

            ConfigSuppressedProperties(x => x.Profession);
            ConfigSuppressedProperties(x => x.Trades);

            ConfigSuppressedResponseProperties(x => x.Profession);
            ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
