using BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagerByKey;
using BAYSOFT.Core.Application.MinecraftTraders.Villagers.Queries.GetVillagersByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class VillagersController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetVillagersByFilterQueryResponse>> Get(GetVillagersByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpGet("{villagerid}")]
        public async Task<ActionResult<GetVillagerByKeyQueryResponse>> Get(GetVillagerByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
    }
}
