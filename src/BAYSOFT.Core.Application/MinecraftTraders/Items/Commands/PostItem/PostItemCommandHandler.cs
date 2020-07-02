using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PostItem
{
    public class PostItemCommandHandler : IRequestHandler<PostItemCommand, PostItemCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PostItemCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostItemCommandResponse> Handle(PostItemCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Items.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostItemCommandResponse(request, data, resultCount: 1);
        }
    }
}
