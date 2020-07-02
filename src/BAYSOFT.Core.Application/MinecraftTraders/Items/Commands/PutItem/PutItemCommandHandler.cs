using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ModelWrapper.Extensions.Put;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PutItem
{
    public class PutItemCommandHandler : IRequestHandler<PutItemCommand, PutItemCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public PutItemCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<PutItemCommandResponse> Handle(PutItemCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ItemID);

            var data = await DefaultDbContext.Items
                .SingleOrDefaultAsync();

            request.Put(data);

            await DefaultDbContext.SaveChangesAsync();

            return new PutItemCommandResponse(request, data, resultCount: 1);
        }
    }
}
