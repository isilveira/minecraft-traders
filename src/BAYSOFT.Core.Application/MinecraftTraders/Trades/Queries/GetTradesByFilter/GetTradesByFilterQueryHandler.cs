using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradesByFilter
{
    public class GetTradesByFilterQueryHandler : IRequestHandler<GetTradesByFilterQuery, GetTradesByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetTradesByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetTradesByFilterQueryResponse> Handle(GetTradesByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Trades
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetTradesByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
