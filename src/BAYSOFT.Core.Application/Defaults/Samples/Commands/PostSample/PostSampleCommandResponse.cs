using BAYSOFT.Core.Domain.Entities.Defaults;
using ModelWrapper;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PostSample
{
    public class PostSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PostSampleCommandResponse()
        {
        }

        public PostSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null) : base(request, data, message, resultCount)
        {
        }
    }
}
