using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PutProfession
{
    public class PutProfessionCommandResponse : ApplicationResponse<Profession>
    {
        public PutProfessionCommandResponse()
        {
        }

        public PutProfessionCommandResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
