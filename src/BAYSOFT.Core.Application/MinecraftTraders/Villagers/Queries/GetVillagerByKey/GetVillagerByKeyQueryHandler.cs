using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagerByKey
{
    public class GetVillagerByKeyQueryHandler : IRequestHandler<GetVillagerByKeyQuery, GetVillagerByKeyQueryResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public GetVillagerByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetVillagerByKeyQueryResponse> Handle(GetVillagerByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.VillagerID);

            var data = await DefaultDbContext.Villagers
                .Where(x => x.VillagerID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Villager not found!");
            }

            return new GetVillagerByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
