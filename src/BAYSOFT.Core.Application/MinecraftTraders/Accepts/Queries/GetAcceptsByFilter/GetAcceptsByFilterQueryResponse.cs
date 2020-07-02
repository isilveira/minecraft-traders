using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptsByFilter
{
    public class GetAcceptsByFilterQueryResponse : ApplicationResponse<Accept>
    {
        public GetAcceptsByFilterQueryResponse()
        {
        }

        public GetAcceptsByFilterQueryResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
