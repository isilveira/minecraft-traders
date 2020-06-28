using BAYSOFT.Core.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ModelWrapper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Presentations.WebAPI.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController: ControllerBase
    {
        private IMediator _mediator;
        private IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

        public async Task<ActionResult<TResponse>> Send<TEntity, TResponse>(ApplicationRequest<TEntity, TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
            where TResponse : ApplicationResponse<TEntity>
        {
            try
            {
                return Ok(await Mediator.Send(request, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(new WrapResponse(400, 4001001, request.RequestObject, null, ex.Message, 0));
            }
        }

        public async Task<TResponse> SendRequest<TEntity, TResponse>(ApplicationRequest<TEntity, TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
            where TResponse : ApplicationResponse<TEntity>
        {
            return await Mediator.Send(request, cancellationToken);
        }
    }
}
