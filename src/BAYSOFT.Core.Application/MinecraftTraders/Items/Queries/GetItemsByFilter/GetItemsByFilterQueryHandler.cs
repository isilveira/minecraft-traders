using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemsByFilter
{
    public class GetItemsByFilterQueryHandler : IRequestHandler<GetItemsByFilterQuery, GetItemsByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetItemsByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetItemsByFilterQueryResponse> Handle(GetItemsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Items
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetItemsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
