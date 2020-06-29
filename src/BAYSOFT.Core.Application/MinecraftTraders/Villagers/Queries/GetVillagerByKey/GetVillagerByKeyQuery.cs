using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagerByKey
{
    public class GetVillagerByKeyQuery : ApplicationRequest<Villager, GetVillagerByKeyQueryResponse>
    {
        public GetVillagerByKeyQuery()
        {
            ConfigKeys(x => x.VillagerID);

            ConfigSuppressedProperties(x => x.Profession);
            ConfigSuppressedProperties(x => x.Trades);

            ConfigSuppressedResponseProperties(x => x.Profession);
            ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
