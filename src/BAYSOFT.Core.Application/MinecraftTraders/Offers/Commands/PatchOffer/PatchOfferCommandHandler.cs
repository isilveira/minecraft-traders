using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer
{
    public class PatchOfferCommandHandler : IRequestHandler<PatchOfferCommand, PatchOfferCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PatchOfferCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchOfferCommandResponse> Handle(PatchOfferCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OfferID);

            var data = await DefaultDbContext.Offers
                .SingleOrDefaultAsync(x => x.OfferID == id);

            if (data == null)
            {
                throw new Exception("Offer not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PatchOfferCommandResponse(request, data, resultCount: 1);
        }
    }
}
