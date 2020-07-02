using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PutItem
{
    public class PutItemCommandResponse : ApplicationResponse<Item>
    {
        public PutItemCommandResponse()
        {
        }

        public PutItemCommandResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
