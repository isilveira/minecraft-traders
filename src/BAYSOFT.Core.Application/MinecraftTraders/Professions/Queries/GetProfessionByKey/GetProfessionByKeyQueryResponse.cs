using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionByKey
{
    public class GetProfessionByKeyQueryResponse : ApplicationResponse<Profession>
    {
        public GetProfessionByKeyQueryResponse()
        {
        }

        public GetProfessionByKeyQueryResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
