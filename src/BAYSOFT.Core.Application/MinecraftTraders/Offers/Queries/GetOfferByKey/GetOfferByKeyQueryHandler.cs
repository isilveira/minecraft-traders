using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOfferByKey
{
    public class GetOfferByKeyQueryHandler : IRequestHandler<GetOfferByKeyQuery, GetOfferByKeyQueryResponse>
    {
        public IDefaultDbContext DefaultDbContext{ get; set; }
        public GetOfferByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetOfferByKeyQueryResponse> Handle(GetOfferByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.OfferID);

            var data = await DefaultDbContext.Offers
                .Where(x => x.OfferID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data ==null)
            {
                throw new Exception("Offer not found!");
            }

            return new GetOfferByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
