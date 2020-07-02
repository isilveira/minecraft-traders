using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PostAccept
{
    public class PostAcceptCommand : ApplicationRequest<Accept, PostAcceptCommandResponse>
    {
        public PostAcceptCommand()
        {
            ConfigKeys(x => x.AcceptID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
