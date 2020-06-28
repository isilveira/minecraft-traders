using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PostSample
{
    public class PostSampleCommand : ApplicationRequest<Sample, PostSampleCommandResponse>
    {
        public PostSampleCommand()
        {
        }
    }
}
