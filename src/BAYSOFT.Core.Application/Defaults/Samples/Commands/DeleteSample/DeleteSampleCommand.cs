using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Commands.DeleteSample
{
    public class DeleteSampleCommand : ApplicationRequest<Sample, DeleteSampleCommandResponse>
    {
        public DeleteSampleCommand()
        {
        }
    }
}
