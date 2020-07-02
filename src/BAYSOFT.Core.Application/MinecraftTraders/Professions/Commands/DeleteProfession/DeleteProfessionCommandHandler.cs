using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.DeleteProfession
{
    public class DeleteProfessionCommandHandler : IRequestHandler<DeleteProfessionCommand, DeleteProfessionCommandResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public DeleteProfessionCommandHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<DeleteProfessionCommandResponse> Handle(DeleteProfessionCommand request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ProfessionID);

            var data = await DefaultDbContext.Professions
                .SingleOrDefaultAsync(x => x.ProfessionID == id, cancellationToken);

            if (data == null)
            {
                throw new Exception("Profession not found!");
            }

            DefaultDbContext.Professions.Remove(data);

            await DefaultDbContext.SaveChangesAsync(cancellationToken);

            return new DeleteProfessionCommandResponse(request, data, resultCount: 1);
        }
    }
}
