using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSamplesByFilter
{
    public class GetSamplesByFilterQueryHandler : IRequestHandler<GetSamplesByFilterQuery, GetSamplesByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetSamplesByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetSamplesByFilterQueryResponse> Handle(GetSamplesByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Samples
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetSamplesByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
