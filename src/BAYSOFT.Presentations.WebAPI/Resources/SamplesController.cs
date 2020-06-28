using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.DeleteSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PatchSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PostSample;
using BAYSOFT.Core.Application.Defaults.Samples.Commands.PutSample;
using BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSampleByKey;
using BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSamplesByFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class SamplesController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetSamplesByFilterQueryResponse>> Get(GetSamplesByFilterQuery query, CancellationToken cancellationToken)
        {
            return await Send(query);
        }
        [HttpGet("{sampleid}")]
        public async Task<ActionResult<GetSampleByKeyQueryResponse>> Get(GetSampleByKeyQuery query, CancellationToken cancellationToken)
        {
            return await Send(query);
        }
        [HttpPost]
        public async Task<ActionResult<PostSampleCommandResponse>> Post(PostSampleCommand command, CancellationToken cancellationToken)
        {
            return await Send(command);
        }
        [HttpPut]
        public async Task<ActionResult<PutSampleCommandResponse>> Put(PutSampleCommand command, CancellationToken cancellationToken)
        {
            return await Send(command);
        }
        [HttpPatch]
        public async Task<ActionResult<PatchSampleCommandResponse>> Patch(PatchSampleCommand command, CancellationToken cancellationToken)
        {
            return await Send(command);
        }
        [HttpDelete]
        public async Task<ActionResult<DeleteSampleCommandResponse>> Delete(DeleteSampleCommand command, CancellationToken cancellationToken)
        {
            return await Send(command);
        }
    }
}
