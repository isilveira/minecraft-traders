using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PutTrade
{
    public class PutTradeCommandHandler : IRequestHandler<PutTradeCommand, PutTradeCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PutTradeCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutTradeCommandResponse> Handle(PutTradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.TradeID);

            var data = await DefaultDbContext.Trades
                .SingleOrDefaultAsync(x => x.TradeID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Trade not found!");
            }

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PutTradeCommandResponse(request, data, resultCount: 1);
        }
    }
}
