using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PutSample
{
    public class PutSampleCommand : ApplicationRequest<Sample, PutSampleCommandResponse>
    {
        public PutSampleCommand()
        {
        }
    }
}
