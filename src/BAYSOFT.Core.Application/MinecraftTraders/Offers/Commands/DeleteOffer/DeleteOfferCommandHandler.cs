using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, DeleteOfferCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteOfferCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteOfferCommandResponse> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OfferID);

            var data = await DefaultDbContext.Offers
                .SingleOrDefaultAsync(x => x.OfferID == id);

            if (data == null)
            {
                throw new Exception("Offer not found!");
            }

            DefaultDbContext.Offers.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteOfferCommandResponse(request, data, resultCount: 1);
        }
    }
}
