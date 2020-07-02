using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PutAccept
{
    public class PutAcceptCommandHandler : IRequestHandler<PutAcceptCommand, PutAcceptCommandResponse>
    {
        public PutAcceptCommandHandler()
        {
        }

        public Task<PutAcceptCommandResponse> Handle(PutAcceptCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
