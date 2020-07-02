using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.DeleteProfession
{
    public class DeleteProfessionCommand : ApplicationRequest<Profession, DeleteProfessionCommandResponse>
    {
        public DeleteProfessionCommand()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.Villagers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Villagers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
