using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PostItem
{
    public class PostItemCommandResponse : ApplicationResponse<Item>
    {
        public PostItemCommandResponse()
        {
        }

        public PostItemCommandResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
