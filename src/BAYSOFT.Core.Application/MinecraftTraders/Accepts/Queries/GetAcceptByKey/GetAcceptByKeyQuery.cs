using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptByKey
{
    public class GetAcceptByKeyQuery : ApplicationRequest<Accept, GetAcceptByKeyQueryResponse>
    {
        public GetAcceptByKeyQuery()
        {
            ConfigKeys(x => x.AcceptID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
