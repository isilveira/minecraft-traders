using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using ModelWrapper.Extensions.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PostOffer
{
    public class PostOfferCommandHandler : IRequestHandler<PostOfferCommand, PostOfferCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PostOfferCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PostOfferCommandResponse> Handle(PostOfferCommand request, CancellationToken cancellationToken)
        {
            var data = request.Post();

            await DefaultDbContext.Offers.AddAsync(data, cancellationToken);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PostOfferCommandResponse(request, data, resultCount: 1);
        }
    }
}
