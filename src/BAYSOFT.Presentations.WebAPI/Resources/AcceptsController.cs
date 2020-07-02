using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.DeleteAccept;
using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PatchAccept;
using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PostAccept;
using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Commands.PutAccept;
using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptByKey;
using BAYSOFT.Core.Application.MinecraftTraders.Accepts.Queries.GetAcceptsByFilter;
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
        [HttpGet("{acceptid}")]
        public async Task<ActionResult<GetAcceptByKeyQueryResponse>> Get(GetAcceptByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<PostAcceptCommandResponse>> Post(PostAcceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{acceptid}")]
        public async Task<ActionResult<PutAcceptCommandResponse>> Put(PutAcceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{acceptid}")]
        public async Task<ActionResult<PatchAcceptCommandResponse>> Patch(PatchAcceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{acceptid}")]
        public async Task<ActionResult<DeleteAcceptCommandResponse>> Delete(DeleteAcceptCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
