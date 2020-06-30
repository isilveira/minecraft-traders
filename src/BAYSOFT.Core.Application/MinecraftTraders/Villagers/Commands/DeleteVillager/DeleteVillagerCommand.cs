using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;
using BAYSOFT.Core.Application.MinecraftTraders.Villagers;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.DeleteVillager
{
    public class DeleteVillagerCommand : ApplicationRequest<Villager, DeleteVillagerCommandResponse>
    {
        public DeleteVillagerCommand()
        {
            ConfigKeys(x => x.VillagerID);

            ConfigSuppressedProperties(x => x.Profession);
            ConfigSuppressedProperties(x => x.Trades);

            ConfigSuppressedResponseProperties(x => x.Profession);
            ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
