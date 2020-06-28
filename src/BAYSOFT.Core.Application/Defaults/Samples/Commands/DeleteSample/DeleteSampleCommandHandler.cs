using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommandHandler : IRequestHandler<DeleteSampleCommand, DeleteSampleCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteSampleCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteSampleCommandResponse> Handle(DeleteSampleCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.SampleID);

            var data = await DefaultDbContext.Samples
                .SingleOrDefaultAsync(x => x.SampleID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Sample not found!");
            }

            DefaultDbContext.Samples.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteSampleCommandResponse(request, data, resultCount: 1);
        }
    }
}
