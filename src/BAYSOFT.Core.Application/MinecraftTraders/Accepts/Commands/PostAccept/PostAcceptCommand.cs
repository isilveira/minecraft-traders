using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PostAccept
{
    public class PostAcceptCommand : ApplicationRequest<Villager, PostAcceptCommandResponse>
    {
        public PostAcceptCommand()
        {
        }
    }
}
