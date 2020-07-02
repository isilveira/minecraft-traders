using BAYSOFT.Core.Domain.Entities.MinecraftTraders;
using ModelWrapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PostProfession
{
    public class PostProfessionCommandResponse : ApplicationResponse<Profession>
    {
        public PostProfessionCommandResponse()
        {
        }

        public PostProfessionCommandResponse(WrapRequest<Profession> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
