using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PutVillager
{
    public class PutVillagerCommand : ApplicationRequest<Villager, PutVillagerCommandResponse>
    {
        public PutVillagerCommand()
        {
            ConfigKeys(x => x.VillagerID);

            ConfigSuppressedProperties(x => x.Profession);
            ConfigSuppressedProperties(x => x.Trades);

            ConfigSuppressedResponseProperties(x => x.Profession);
            ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
