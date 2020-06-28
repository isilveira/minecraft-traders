using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.PatchSample
{
    public class PatchSampleCommand : ApplicationRequest<Sample, PatchSampleCommandResponse>
    {
        public PatchSampleCommand()
        {
        }
    }
}
