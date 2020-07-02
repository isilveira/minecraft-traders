using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PostProfession
{
    public class PostProfessionCommandHandler : IRequestHandler<PostProfessionCommand, PostProfessionCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PostProfessionCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostProfessionCommandResponse> Handle(PostProfessionCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Professions.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostProfessionCommandResponse(request, data, resultCount: 1);
        }
    }
}
