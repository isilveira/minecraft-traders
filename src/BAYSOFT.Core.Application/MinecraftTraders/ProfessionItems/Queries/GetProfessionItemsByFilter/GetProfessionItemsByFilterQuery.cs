using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.ProfessionItems.Queries.GetProfessionItemsByFilter
{
    public class GetProfessionItemsByFilterQuery : ApplicationRequest<ProfessionItem, GetProfessionItemsByFilterQueryResponse>
    {
        public GetProfessionItemsByFilterQuery()
        {
            ConfigKeys(x => x.ItemID);
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Profession);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Profession);
        }
    }
}
