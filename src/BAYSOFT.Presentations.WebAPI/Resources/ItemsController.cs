using BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.DeleteItem;
using BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PatchItem;
using BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PostItem;
using BAYSOFT.Core.Application.MinecraftTraders.Items.Commands.PutItem;
using BAYSOFT.Core.Application.MinecraftTraders.Items.Queries.GetItemByKey;
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
        [HttpGet("{itemid}")]
        public async Task<ActionResult<GetItemByKeyQueryResponse>> Get(GetItemByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<PostItemCommandResponse>> Post(PostItemCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{itemid}")]
        public async Task<ActionResult<PutItemCommandResponse>> Put(PutItemCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{itemid}")]
        public async Task<ActionResult<PatchItemCommandResponse>> Patch(PatchItemCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{itemid}")]
        public async Task<ActionResult<DeleteItemCommandResponse>> Delete(DeleteItemCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
