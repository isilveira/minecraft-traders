using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Select;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionByKey
{
    public class GetProfessionByKeyQueryHandler : IRequestHandler<GetProfessionByKeyQuery, GetProfessionByKeyQueryResponse>
    {
        public IDefaultDbContext DefaultDbContext { get; set; }
        public GetProfessionByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetProfessionByKeyQueryResponse> Handle(GetProfessionByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ProfessionID);

            var data = await DefaultDbContext.Professions
                .Where(x => x.ProfessionID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data==null)
            {
                throw new Exception("Profession not found!");
            }

            return new GetProfessionByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
