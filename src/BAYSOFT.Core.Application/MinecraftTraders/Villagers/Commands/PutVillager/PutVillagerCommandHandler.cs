using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PutVillager
{
    public class PutVillagerCommandHandler : IRequestHandler<PutVillagerCommand, PutVillagerCommandResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public PutVillagerCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutVillagerCommandResponse> Handle(PutVillagerCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.VillagerID);

            var data = await DefaultDbContext.Villagers
                .SingleOrDefaultAsync();

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PutVillagerCommandResponse(request, data, resultCount: 1);
        }
    }
}
