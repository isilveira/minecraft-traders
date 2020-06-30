﻿using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PutVillager
{
    public class PutVillagerCommandResponse : ApplicationResponse<Villager>
    {
        public PutVillagerCommandResponse()
        {
        }

        public PutVillagerCommandResponse(WrapRequest<Villager> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}