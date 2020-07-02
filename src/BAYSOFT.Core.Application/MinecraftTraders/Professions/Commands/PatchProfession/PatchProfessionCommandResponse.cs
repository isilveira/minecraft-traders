using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PatchProfession
{
    public class PatchProfessionCommandResponse : ApplicationResponse<Profession>
    {
        public PatchProfessionCommandResponse()
        {
        }

        public PatchProfessionCommandResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
