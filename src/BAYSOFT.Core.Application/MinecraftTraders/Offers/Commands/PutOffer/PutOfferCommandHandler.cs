using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer
{
    public class PutOfferCommandHandler : IRequestHandler<PutOfferCommand, PutOfferCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PutOfferCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutOfferCommandResponse> Handle(PutOfferCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OfferID);

            var data = await DefaultDbContext.Offers
                .SingleOrDefaultAsync();

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PutOfferCommandResponse(request, data, resultCount: 1);
        }
    }
}
