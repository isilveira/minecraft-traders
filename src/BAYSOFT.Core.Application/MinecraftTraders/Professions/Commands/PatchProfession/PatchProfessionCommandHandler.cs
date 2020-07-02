using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PatchProfession
{
    public class PatchProfessionCommandHandler : IRequestHandler<PatchProfessionCommand, PatchProfessionCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PatchProfessionCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchProfessionCommandResponse> Handle(PatchProfessionCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ProfessionID);

            var data = await DefaultDbContext.Professions
                .SingleOrDefaultAsync(x => x.ProfessionID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Profession not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PatchProfessionCommandResponse(request, data, resultCount: 1);
        }
    }
}
