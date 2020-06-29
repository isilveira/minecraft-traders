using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagersByFilter
{
    public class GetVillagersByFilterQueryHandler : IRequestHandler<GetVillagersByFilterQuery, GetVillagersByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetVillagersByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetVillagersByFilterQueryResponse> Handle(GetVillagersByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Villagers
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetVillagersByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
