using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemByKey
{
    public class GetItemByKeyQuery : ApplicationRequest<Item, GetItemByKeyQueryResponse>
    {
        public GetItemByKeyQuery()
        {
            ConfigKeys(x => x.ItemID);

            ConfigSuppressedProperties(x => x.Accepts);
            ConfigSuppressedProperties(x => x.Offers);
            ConfigSuppressedProperties(x => x.ProfessionItems);

            ConfigSuppressedResponseProperties(x => x.Accepts);
            ConfigSuppressedResponseProperties(x => x.Offers);
            ConfigSuppressedResponseProperties(x => x.ProfessionItems);
        }
    }
}
