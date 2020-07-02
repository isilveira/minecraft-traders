using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptsByFilter
{
    public class GetAcceptsByFilterQueryHandler : IRequestHandler<GetAcceptsByFilterQuery, GetAcceptsByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetAcceptsByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetAcceptsByFilterQueryResponse> Handle(GetAcceptsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Accepts
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetAcceptsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
