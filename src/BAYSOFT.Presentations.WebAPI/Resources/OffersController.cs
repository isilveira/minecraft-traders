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
    }
}
