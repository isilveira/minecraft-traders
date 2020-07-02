using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptsByFilter
{
    public class GetAcceptsByFilterQuery : ApplicationRequest<Accept, GetAcceptsByFilterQueryResponse>
    {
        public GetAcceptsByFilterQuery()
        {
            ConfigKeys(x => x.AcceptID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
