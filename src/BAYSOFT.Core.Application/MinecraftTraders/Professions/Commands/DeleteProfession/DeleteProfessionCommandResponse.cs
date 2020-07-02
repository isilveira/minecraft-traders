using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.DeleteProfession
{
    public class DeleteProfessionCommandResponse : ApplicationResponse<Profession>
    {
        public DeleteProfessionCommandResponse()
        {
        }

        public DeleteProfessionCommandResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
