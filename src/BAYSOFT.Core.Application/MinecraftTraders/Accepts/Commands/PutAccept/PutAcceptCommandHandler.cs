using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PutAccept
{
    public class PutAcceptCommandHandler : IRequestHandler<PutAcceptCommand, PutAcceptCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PutAcceptCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutAcceptCommandResponse> Handle(PutAcceptCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.AcceptID);

            var data = await DefaultDbContext.Accepts
                .SingleOrDefaultAsync();

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PutAcceptCommandResponse(request, data, resultCount: 1);
        }
    }
}
