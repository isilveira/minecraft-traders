using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PatchAccept
{
    public class PatchAcceptCommandHandler : IRequestHandler<PatchAcceptCommand, PatchAcceptCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PatchAcceptCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchAcceptCommandResponse> Handle(PatchAcceptCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.AcceptID);

            var data = await DefaultDbContext.Accepts
                .SingleOrDefaultAsync(x => x.AcceptID == id);

            if (data == null)
            {
                throw new Exception("Accept not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PatchAcceptCommandResponse(request, data, resultCount: 1);
        }
    }
}
