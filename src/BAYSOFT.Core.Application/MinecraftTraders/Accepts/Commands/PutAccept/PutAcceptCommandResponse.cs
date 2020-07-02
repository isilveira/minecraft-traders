using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PutAccept
{
    public class PutAcceptCommandResponse : ApplicationResponse<Accept>
    {
        public PutAcceptCommandResponse()
        {
        }

        public PutAcceptCommandResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
