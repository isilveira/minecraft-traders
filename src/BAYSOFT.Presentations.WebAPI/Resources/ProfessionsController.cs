using BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionByKey;
using BAYSOFT.Core.Application.MinecraftTraders.Professions.Queries.GetProfessionsByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class ProfessionsController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetProfessionsByFilterQueryResponse>> Get(GetProfessionsByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpGet("{professionid}")]
        public async Task<ActionResult<GetProfessionByKeyQueryResponse>> Get(GetProfessionByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
    }
}
