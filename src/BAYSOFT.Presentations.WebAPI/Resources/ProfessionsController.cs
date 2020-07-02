using BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.DeleteProfession;
using BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PatchProfession;
using BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PostProfession;
using BAYSOFT.Core.Application.MinecraftTraders.Professions.Commands.PutProfession;
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
        [HttpPost]
        public async Task<ActionResult<PostProfessionCommandResponse>> Post(PostProfessionCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{professionid}")]
        public async Task<ActionResult<PutProfessionCommandResponse>> Put(PutProfessionCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{professionid}")]
        public async Task<ActionResult<PatchProfessionCommandResponse>> Patch(PatchProfessionCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{professionid}")]
        public async Task<ActionResult<DeleteProfessionCommandResponse>> Delete(DeleteProfessionCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
