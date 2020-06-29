using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptByKey
{
    public class GetAcceptByKeyQueryResponse : ApplicationResponse<Accept>
    {
        public GetAcceptByKeyQueryResponse()
        {
        }

        public GetAcceptByKeyQueryResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
