using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemsByFilter
{
    public class GetItemsByFilterQueryResponse : ApplicationResponse<Item>
    {
        public GetItemsByFilterQueryResponse()
        {
        }

        public GetItemsByFilterQueryResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
