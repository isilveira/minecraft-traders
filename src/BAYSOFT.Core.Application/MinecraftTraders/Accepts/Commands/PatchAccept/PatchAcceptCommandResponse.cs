using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PatchAccept
{
    public class PatchAcceptCommandResponse : ApplicationResponse<Accept>
    {
        public PatchAcceptCommandResponse()
        {
        }

        public PatchAcceptCommandResponse(WrapRequest<Accept> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
