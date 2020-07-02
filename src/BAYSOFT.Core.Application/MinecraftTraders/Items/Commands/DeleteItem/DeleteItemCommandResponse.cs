using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.DeleteItem
{
    public class DeleteItemCommandResponse : ApplicationResponse<Item>
    {
        public DeleteItemCommandResponse()
        {
        }

        public DeleteItemCommandResponse(WrapRequest<Item> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
