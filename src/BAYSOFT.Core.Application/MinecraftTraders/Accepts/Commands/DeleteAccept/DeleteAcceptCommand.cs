using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.DeleteAccept
{
    public class DeleteAcceptCommand : ApplicationRequest<Villager, DeleteAcceptCommandResponse>
    {
        public DeleteAcceptCommand()
        {
        }
    }
}
