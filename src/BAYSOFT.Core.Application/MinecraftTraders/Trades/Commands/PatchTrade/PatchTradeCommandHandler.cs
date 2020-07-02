using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PatchTrade
{
    public class PatchTradeCommandHandler : IRequestHandler<PatchTradeCommand, PatchTradeCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }

        public PatchTradeCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchTradeCommandResponse> Handle(PatchTradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.TradeID);

            var data = await DefaultDbContext.Trades
                .SingleOrDefaultAsync(x => x.TradeID == id, cancellationToken);

            if (data==null)
            {
                throw new Exception("Trade not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PatchTradeCommandResponse(request, data, resultCount: 1);
        }
    }
}
