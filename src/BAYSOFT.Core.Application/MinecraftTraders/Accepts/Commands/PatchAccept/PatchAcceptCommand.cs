using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PatchAccept
{
    public class PatchAcceptCommand : ApplicationRequest<Villager, PatchAcceptCommandResponse>
    {
        public PatchAcceptCommand()
        {
        }
    }
}
