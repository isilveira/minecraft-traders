using BAYSOFT.Core.Application.Defaults.Samples.Commands.DeleteSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PatchSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PostSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PutSample;
using BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSampleByKey;
using BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSamplesByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class SamplesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSamplesByFilterQueryResponse>> Get(GetSamplesByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpGet("{sampleid}")]
        public async Task<ActionResult<GetSampleByKeyQueryResponse>> Get(GetSampleByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<PostSampleCommandResponse>> Post(PostSampleCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{sampleid}")]
        public async Task<ActionResult<PutSampleCommandResponse>> Put(PutSampleCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{sampleid}")]
        public async Task<ActionResult<PatchSampleCommandResponse>> Patch(PatchSampleCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{sampleid}")]
        public async Task<ActionResult<DeleteSampleCommandResponse>> Delete(DeleteSampleCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
