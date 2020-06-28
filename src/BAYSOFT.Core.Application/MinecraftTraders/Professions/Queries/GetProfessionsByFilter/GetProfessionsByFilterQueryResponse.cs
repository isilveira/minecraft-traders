using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionsByFilter
{
    public class GetProfessionsByFilterQueryResponse : ApplicationResponse<Profession>
    {
        public GetProfessionsByFilterQueryResponse()
        {
        }

        public GetProfessionsByFilterQueryResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
