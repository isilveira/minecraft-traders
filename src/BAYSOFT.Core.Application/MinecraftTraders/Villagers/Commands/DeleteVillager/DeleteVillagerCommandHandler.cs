using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.DeleteVillager
{
    public class DeleteVillagerCommandHandler : IRequestHandler<DeleteVillagerCommand, DeleteVillagerCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteVillagerCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteVillagerCommandResponse> Handle(DeleteVillagerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.VillagerID);

            var data = await DefaultDbContext.Villagers
                .SingleOrDefaultAsync(x => x.VillagerID == id);

            if (data == null)
            {
                throw new Exception("Villager not found!");
            }

            DefaultDbContext.Villagers.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteVillagerCommandResponse(request, data, resultCount: 1);
        }
    }
}
