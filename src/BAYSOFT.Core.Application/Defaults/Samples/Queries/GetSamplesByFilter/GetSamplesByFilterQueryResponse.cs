using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSamplesByFilter
{
    public class GetSamplesByFilterQueryResponse : ApplicationResponse<Sample>
    {
        public GetSamplesByFilterQueryResponse()
        {
        }

        public GetSamplesByFilterQueryResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
