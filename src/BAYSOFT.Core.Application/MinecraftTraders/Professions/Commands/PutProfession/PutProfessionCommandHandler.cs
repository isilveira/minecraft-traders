using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PutProfession
{
    public class PutProfessionCommandHandler : IRequestHandler<PutProfessionCommand, PutProfessionCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PutProfessionCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutProfessionCommandResponse> Handle(PutProfessionCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ProfessionID);

            var data = await DefaultDbContext.Professions
                .SingleOrDefaultAsync(x => x.ProfessionID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Trade not found!");
            }

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PutProfessionCommandResponse(request, data, resultCount: 1);
        }
    }
}
