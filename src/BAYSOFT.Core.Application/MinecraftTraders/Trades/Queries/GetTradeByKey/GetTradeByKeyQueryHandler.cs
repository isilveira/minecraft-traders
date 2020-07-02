using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradeByKey
{
    public class GetTradeByKeyQueryHandler : IRequestHandler<GetTradeByKeyQuery, GetTradeByKeyQueryResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public GetTradeByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetTradeByKeyQueryResponse> Handle(GetTradeByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.TradeID);

            var data = await DefaultDbContext.Trades
                .Where(x => x.TradeID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Trade not found!");
            }

            return new GetTradeByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
