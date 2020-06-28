using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PatchSample
{
    public class PatchSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PatchSampleCommandResponse()
        {
        }

        public PatchSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
