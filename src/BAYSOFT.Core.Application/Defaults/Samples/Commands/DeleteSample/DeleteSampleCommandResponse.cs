using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommandResponse : ApplicationResponse<Sample>
    {
        public DeleteSampleCommandResponse()
        {
        }

        public DeleteSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
