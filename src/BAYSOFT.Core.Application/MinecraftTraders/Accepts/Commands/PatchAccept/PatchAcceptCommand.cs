﻿using BAYSOFT.Core.Domain.Entities.MinecraftTraders;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PatchAccept
{
    public class PatchAcceptCommand : ApplicationRequest<Accept, PatchAcceptCommandResponse>
    {
        public PatchAcceptCommand()
        {
            ConfigKeys(x => x.AcceptID);

            ConfigSuppressedProperties(x => x.Item);
            ConfigSuppressedProperties(x => x.Trade);

            ConfigSuppressedResponseProperties(x => x.Item);
            ConfigSuppressedResponseProperties(x => x.Trade);
        }
    }
}
