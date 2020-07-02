using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.DeleteTrade
{
    public class DeleteTradeCommandHandler : IRequestHandler<DeleteTradeCommand, DeleteTradeCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteTradeCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteTradeCommandResponse> Handle(DeleteTradeCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.TradeID);

            var data = await DefaultDbContext.Trades.SingleOrDefaultAsync(x => x.TradeID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Trade not found!");
            }

            DefaultDbContext.Trades.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteTradeCommandResponse(request, data, resultCount: 1);
        }
    }
}
