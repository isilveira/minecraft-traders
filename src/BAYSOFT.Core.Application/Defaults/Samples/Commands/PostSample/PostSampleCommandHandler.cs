using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PostSample
{
    public class PostSampleCommandHandler : IRequestHandler<PostSampleCommand, PostSampleCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PostSampleCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostSampleCommandResponse> Handle(PostSampleCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Samples.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostSampleCommandResponse(request, data, resultCount: 1);
        }
    }
}
