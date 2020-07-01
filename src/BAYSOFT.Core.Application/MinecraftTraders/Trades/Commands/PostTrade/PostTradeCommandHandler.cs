using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PostTrade
{
    public class PostTradeCommandHandler : IRequestHandler<PostTradeCommand, PostTradeCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PostTradeCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostTradeCommandResponse> Handle(PostTradeCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Trades.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostTradeCommandResponse(request, data, resultCount: 1);
        }
    }
}
