using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PutSample
{
    public class PutSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PutSampleCommandResponse()
        {
        }

        public PutSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
