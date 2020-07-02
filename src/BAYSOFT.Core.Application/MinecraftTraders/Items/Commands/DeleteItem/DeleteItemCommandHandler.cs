using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, DeleteItemCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteItemCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteItemCommandResponse> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ItemID);

            var data = await DefaultDbContext.Items
                .SingleOrDefaultAsync(x => x.ItemID == id);

            if (data == null)
            {
                throw new Exception("Item not found!");
            }

            DefaultDbContext.Items.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteItemCommandResponse(request, data, resultCount: 1);
        }
    }
}
