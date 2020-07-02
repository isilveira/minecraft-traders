using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionByKey
{
    public class GetProfessionByKeyQuery : ApplicationRequest<Profession, GetProfessionByKeyQueryResponse>
    {
        public GetProfessionByKeyQuery()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.ProfessionItems);
            ConfigSuppressedProperties(x => x.Villagers);

            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
            ConfigSuppressedResponseProperties(x => x.Villagers);
        }
    }
}
