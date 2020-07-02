using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PostAccept
{
    public class PostAcceptCommandResponse : ApplicationResponse<Accept>
    {
        public PostAcceptCommandResponse()
        {
        }

        public PostAcceptCommandResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
