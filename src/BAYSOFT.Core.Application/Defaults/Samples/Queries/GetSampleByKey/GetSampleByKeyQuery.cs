using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSampleByKey
{
    public class GetSampleByKeyQuery : ApplicationRequest<Sample, GetSampleByKeyQueryResponse>
    {
        public GetSampleByKeyQuery()
        {
        }
    }
}
