using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.ProfessionItems.Queries.GetProfessionItemsByFilter
{
    public class GetProfessionItemsByFilterQueryHandler : IRequestHandler<GetProfessionItemsByFilterQuery, GetProfessionItemsByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetProfessionItemsByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetProfessionItemsByFilterQueryResponse> Handle(GetProfessionItemsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.ProfessionItems
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetProfessionItemsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
