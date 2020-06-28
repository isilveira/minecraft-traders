using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ModelWrapper.Extensions.Select;
using Microsoft.EntityFrameworkCore;
using System;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSampleByKey
{
    public class GetSampleByKeyQueryHandler : IRequestHandler<GetSampleByKeyQuery, GetSampleByKeyQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetSampleByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetSampleByKeyQueryResponse> Handle(GetSampleByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SampleID);

            var data = await DefaultDbContext.Samples
                .Where(x => x.SampleID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Sample not found!");
            }

            return new GetSampleByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
