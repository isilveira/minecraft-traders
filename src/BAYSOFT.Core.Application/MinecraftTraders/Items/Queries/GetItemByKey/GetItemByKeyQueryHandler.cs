using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModelWrapper.Extensions.Select;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemByKey
{
    public class GetItemByKeyQueryHandler : IRequestHandler<GetItemByKeyQuery, GetItemByKeyQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetItemByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetItemByKeyQueryResponse> Handle(GetItemByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.ItemID);

            var data = await DefaultDbContext.Items
                .Where(x => x.ItemID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Item not found!");
            }

            return new GetItemByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
