using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PutAccept
{
    public class PutAcceptCommand : ApplicationRequest<Villager, PutAcceptCommandResponse>
    {
        public PutAcceptCommand()
        {
        }
    }
}
