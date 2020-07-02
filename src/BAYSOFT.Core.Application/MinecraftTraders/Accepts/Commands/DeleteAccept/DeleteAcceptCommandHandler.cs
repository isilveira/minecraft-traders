using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.DeleteAccept
{
    public class DeleteAcceptCommandHandler : IRequestHandler<DeleteAcceptCommand, DeleteAcceptCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteAcceptCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteAcceptCommandResponse> Handle(DeleteAcceptCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.AcceptID);

            var data = await DefaultDbContext.Accepts
                .SingleOrDefaultAsync(x => x.AcceptID == id);

            if (data == null)
            {
                throw new Exception("Accept not found!");
            }

            DefaultDbContext.Accepts.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteAcceptCommandResponse(request, data, resultCount: 1);
        }
    }
}
