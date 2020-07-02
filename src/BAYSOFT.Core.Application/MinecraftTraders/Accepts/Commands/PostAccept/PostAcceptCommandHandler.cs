using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PostAccept
{
    public class PostAcceptCommandHandler : IRequestHandler<PostAcceptCommand, PostAcceptCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PostAcceptCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostAcceptCommandResponse> Handle(PostAcceptCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Accepts.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostAcceptCommandResponse(request, data, resultCount: 1);
        }
    }
}
