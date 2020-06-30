using BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PatchVillager;
using BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PostVillager;
using BAYSOFT.Core.Application.MinecraftTraders.Villagers.Commands.PutVillager;
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
        [HttpPost]
        public async Task<ActionResult<PostVillagerCommandResponse>> Post(PostVillagerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{villagerid}")]
        public async Task<ActionResult<PutVillagerCommandResponse>> Put(PutVillagerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{villagerid}")]
        public async Task<ActionResult<PatchVillagerCommandResponse>> Patch(PatchVillagerCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
