using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PostVillager
{
    public class PostVillagerCommandHandler : IRequestHandler<PostVillagerCommand, PostVillagerCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PostVillagerCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostVillagerCommandResponse> Handle(PostVillagerCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Villagers.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostVillagerCommandResponse(request, data, resultCount: 1);
        }
    }
}
