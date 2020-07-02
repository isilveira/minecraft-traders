using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

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
