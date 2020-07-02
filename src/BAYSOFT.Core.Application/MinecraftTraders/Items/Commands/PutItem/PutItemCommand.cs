using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PutItem
{
    public class PutItemCommand : ApplicationRequest<Item, PutItemCommandResponse>
    {
        public PutItemCommand()
        {
            ConfigKeys(x => x.ItemID);

            ConfigSuppressedProperties(x => x.Accepts);
            ConfigSuppressedProperties(x => x.Offers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Accepts);
            ConfigSuppressedResponseProperties(x => x.Offers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
