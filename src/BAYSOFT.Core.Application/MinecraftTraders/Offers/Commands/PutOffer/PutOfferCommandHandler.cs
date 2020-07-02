using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer
{
    public class PutOfferCommandHandler : IRequestHandler<PutOfferCommand, PutOfferCommandResponse>
    {
        public PutOfferCommandHandler()
        {
        }

        public Task<PutOfferCommandResponse> Handle(PutOfferCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
