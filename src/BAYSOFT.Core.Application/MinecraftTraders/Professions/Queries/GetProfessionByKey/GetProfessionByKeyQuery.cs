using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionByKey
{
    public class GetProfessionByKeyQuery : ApplicationRequest<Profession, GetProfessionByKeyQueryResponse>
    {
        public GetProfessionByKeyQuery()
        {
            ConfigKeys(x => x.ProfessionID);

            ConfigSuppressedProperties(x => x.ProfessionItems);
            ConfigSuppressedProperties(x => x.Villagers);

            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
            ConfigSuppressedResponseProperties(x => x.Villagers);
        }
    }
}
