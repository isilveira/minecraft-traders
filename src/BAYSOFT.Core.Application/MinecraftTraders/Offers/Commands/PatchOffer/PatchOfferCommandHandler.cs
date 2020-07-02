using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer
{
    public class PatchOfferCommandHandler : IRequestHandler<PatchOfferCommand, PatchOfferCommandResponse>
    {
        public PatchOfferCommandHandler()
        {
        }

        public Task<PatchOfferCommandResponse> Handle(PatchOfferCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
