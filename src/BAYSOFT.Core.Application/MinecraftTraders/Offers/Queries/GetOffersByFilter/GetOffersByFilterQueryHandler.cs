using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOffersByFilter
{
    public class GetOffersByFilterQueryHandler : IRequestHandler<GetOffersByFilterQuery, GetOffersByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetOffersByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetOffersByFilterQueryResponse> Handle(GetOffersByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Offers
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetOffersByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
