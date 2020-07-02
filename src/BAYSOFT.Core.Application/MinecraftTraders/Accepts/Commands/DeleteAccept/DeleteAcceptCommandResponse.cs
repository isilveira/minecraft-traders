using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.DeleteAccept
{
    public class DeleteAcceptCommandResponse : ApplicationResponse<Accept>
    {
        public DeleteAcceptCommandResponse()
        {
        }

        public DeleteAcceptCommandResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
