using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Patch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PatchItem
{
    public class PatchItemCommandHandler : IRequestHandler<PatchItemCommand, PatchItemCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PatchItemCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PatchItemCommandResponse> Handle(PatchItemCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ItemID);

            var data = await DefaultDbContext.Items
                .SingleOrDefaultAsync(x => x.ItemID == id);

            if (data == null)
            {
                throw new Exception("Item not found!");
            }

            request.Patch(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PatchItemCommandResponse(request, data, resultCount: 1);
        }
    }
}
