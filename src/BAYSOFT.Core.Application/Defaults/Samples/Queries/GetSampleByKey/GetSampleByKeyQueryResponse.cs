using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSampleByKey
{
    public class GetSampleByKeyQueryResponse : ApplicationResponse<Sample>
    {
        public GetSampleByKeyQueryResponse()
        {
        }

        public GetSampleByKeyQueryResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
