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
    }
}
