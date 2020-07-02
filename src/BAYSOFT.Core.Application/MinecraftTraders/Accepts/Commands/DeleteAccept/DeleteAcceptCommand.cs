using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.DeleteAccept
{
    public class DeleteAcceptCommand : ApplicationRequest<Accept, DeleteAcceptCommandResponse>
    {
        public DeleteAcceptCommand()
        {
            ConfigKeys(x => x.AcceptID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
