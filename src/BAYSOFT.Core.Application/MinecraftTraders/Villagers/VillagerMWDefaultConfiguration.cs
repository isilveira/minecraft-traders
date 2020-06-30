using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers
{
    public static class VillagerMWDefaultConfiguration
    {
        public static void ConfigureModelWrapper(this ApplicationRequest<Villager,ApplicationResponse<Villager>> request)
        {
            request.ConfigKeys(x => x.VillagerID);

            request.ConfigSuppressedProperties(x => x.Profession);
            request.ConfigSuppressedProperties(x => x.Trades);

            request.ConfigSuppressedResponseProperties(x => x.Profession);
            request.ConfigSuppressedResponseProperties(x => x.Trades);
        }
    }
}
