using BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemsByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class ItemsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetItemsByFilterQueryResponse>> Get(GetItemsByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
    }
}
