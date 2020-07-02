using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PatchItem
{
    public class PatchItemCommandResponse : ApplicationResponse<Item>
    {
        public PatchItemCommandResponse()
        {
        }

        public PatchItemCommandResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
