using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PatchItem
{
    public class PatchItemCommand : ApplicationRequest<Item, PatchItemCommandResponse>
    {
        public PatchItemCommand()
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
