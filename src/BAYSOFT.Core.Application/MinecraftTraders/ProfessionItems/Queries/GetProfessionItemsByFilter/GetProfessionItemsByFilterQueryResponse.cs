﻿using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.ProfessionItems.Queries.GetProfessionItemsByFilter
{
    public class GetProfessionItemsByFilterQueryResponse : ApplicationResponse<ProfessionItem>
    {
        public GetProfessionItemsByFilterQueryResponse()
        {
        }

        public GetProfessionItemsByFilterQueryResponse(WrapRequest<ProfessionItem> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
