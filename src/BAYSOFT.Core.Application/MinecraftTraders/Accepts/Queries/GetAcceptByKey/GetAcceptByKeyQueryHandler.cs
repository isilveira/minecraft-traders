﻿using BAYSOFT.Core.Domain.Interfaces.Infrastructures.Contexts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ModelWrapper.Extensions.Select;
using Microsoft.EntityFrameworkCore;

namespace BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptByKey
{
    public class GetAcceptByKeyQueryHandler : IRequestHandler<GetAcceptByKeyQuery, GetAcceptByKeyQueryResponse>
    {
        private IDefaultDbContext DefaultDbContext { get; set; }
        public GetAcceptByKeyQueryHandler(IDefaultDbContext defaultDbContext)
        {
            DefaultDbContext = defaultDbContext;
        }

        public async Task<GetAcceptByKeyQueryResponse> Handle(GetAcceptByKeyQuery request, CancellationToken cancellationToken)
        {
            var id = request.Project(x => x.AcceptID);

            var data = await DefaultDbContext.Accepts
                .Where(x => x.AcceptID == id)
                .Select(request)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            if (data == null)
            {
                throw new Exception("Accept not found!");
            }

            return new GetAcceptByKeyQueryResponse(request, data, resultCount: 1);
        }
    }
}
