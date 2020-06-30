using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PatchVillager
{
    public class PatchVillagerCommandHandler : IRequestHandler<PatchVillagerCommand, PatchVillagerCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PatchVillagerCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchVillagerCommandResponse> Handle(PatchVillagerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.VillagerID);

            var data = await DefaultDbContext.Villagers
                .SingleOrDefaultAsync(x => x.VillagerID == id);

            if (data == null)
            {
                throw new Exception("Villager not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PatchVillagerCommandResponse(request, data, resultCount: 1);
        }
    }
}
