﻿using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptsByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class AcceptsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetAcceptsByFilterQueryResponse>> Get(GetAcceptsByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
    }
}
