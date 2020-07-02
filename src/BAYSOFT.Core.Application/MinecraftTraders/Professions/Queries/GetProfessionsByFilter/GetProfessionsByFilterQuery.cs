using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionsByFilter
{
    public class GetProfessionsByFilterQuery : ApplicationRequest<Profession, GetProfessionsByFilterQueryResponse>
    {
        public GetProfessionsByFilterQuery()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.Villagers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Villagers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
