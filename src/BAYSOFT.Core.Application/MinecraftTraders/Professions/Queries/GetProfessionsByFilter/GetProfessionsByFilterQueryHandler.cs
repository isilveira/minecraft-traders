using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.FullSearch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionsByFilter
{
    public class GetProfessionsByFilterQueryHandler : IRequestHandler<GetProfessionsByFilterQuery, GetProfessionsByFilterQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetProfessionsByFilterQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetProfessionsByFilterQueryResponse> Handle(GetProfessionsByFilterQuery request, CancellationToken cancellationToken)
        {
            long resultCount = 0;

            var data = await DefaultDbContext.Professions
                .FullSearch(request, out resultCount)
                .AsNoTracking()
                .ToListAsync();

            return new GetProfessionsByFilterQueryResponse(request, data, resultCount: resultCount);
        }
    }
}
