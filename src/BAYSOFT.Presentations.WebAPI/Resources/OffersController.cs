using BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.DeleteOffer;
using BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PatchOffer;
using BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PostOffer;
using BAYSOFT.Core.Application.MinecraftTraders.Offers.Commands.PutOffer;
using BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOfferByKey;
using BAYSOFT.Core.Application.MinecraftTraders.Offers.Queries.GetOffersByFilter;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    public class OffersController : ResourceController
    {
        [HttpGet]
        public async Task<ActionResult<GetOffersByFilterQueryResponse>> Get(GetOffersByFilterQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpGet("{offerid}")]
        public async Task<ActionResult<GetOfferByKeyQueryResponse>> Get(GetOfferByKeyQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(query, cancellationToken);
        }
        [HttpPost]
        public async Task<ActionResult<PostOfferCommandResponse>> Post(PostOfferCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPut("{offerid}")]
        public async Task<ActionResult<PutOfferCommandResponse>> Put(PutOfferCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpPatch("{offerid}")]
        public async Task<ActionResult<PatchOfferCommandResponse>> Patch(PatchOfferCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
        [HttpDelete("{offerid}")]
        public async Task<ActionResult<DeleteOfferCommandResponse>> Delete(DeleteOfferCommand command, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Send(command, cancellationToken);
        }
    }
}
