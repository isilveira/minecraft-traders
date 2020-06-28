using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PatchSample
{
    public class PatchSampleCommandHandler : IRequestHandler<PatchSampleCommand, PatchSampleCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PatchSampleCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchSampleCommandResponse> Handle(PatchSampleCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SampleID);

            var data = await DefaultDbContext.Samples
                .SingleOrDefaultAsync(x => x.SampleID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Sample not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PatchSampleCommandResponse(request, data, resultCount: 1);
        }
    }
}
