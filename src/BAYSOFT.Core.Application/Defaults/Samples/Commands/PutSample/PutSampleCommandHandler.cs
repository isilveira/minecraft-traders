using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PutSample
{
    public class PutSampleCommandHandler : IRequestHandler<PutSampleCommand, PutSampleCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PutSampleCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutSampleCommandResponse> Handle(PutSampleCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SampleID);

            var data = await DefaultDbContext.Samples
                .SingleOrDefaultAsync(x => x.SampleID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Sample not found!");
            }

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new PutSampleCommandResponse(request, data, resultCount: 1);
        }
    }
}
