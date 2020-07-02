using BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.DeleteTrade;
using BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PatchTrade;
using BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PostTrade;
using BAYSOFT.Core.Application.MinecraftTraders.Trades.Commands.PutTrade;
using BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradeByKey;
using BAYSOFT.Core.Application.MinecraftTraders.Trades.Queries.GetTradesByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class TradesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetTradesByFilterQueryResponse>> Get(GetTradesByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpGet("{tradeid}")]
        public async Task<ActionResult<GetTradeByKeyQueryResponse>> Get(GetTradeByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<PostTradeCommandResponse>> Post(PostTradeCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{tradeid}")]
        public async Task<ActionResult<PutTradeCommandResponse>> Put(PutTradeCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{tradeid}")]
        public async Task<ActionResult<PatchTradeCommandResponse>> Patch(PatchTradeCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{tradeid}")]
        public async Task<ActionResult<DeleteTradeCommandResponse>> Delete(DeleteTradeCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
