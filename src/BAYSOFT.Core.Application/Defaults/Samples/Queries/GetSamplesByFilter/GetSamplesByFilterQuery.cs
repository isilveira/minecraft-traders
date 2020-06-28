using BAYSOFT.Core.Domain.Entities.Defaults;

namespace BAYSOFT.Core.Application.Defaults.Samples.Queries.GetSamplesByFilter
{
    public class GetSamplesByFilterQuery : ApplicationRequest<Sample, GetSamplesByFilterQueryResponse>
    {
        public GetSamplesByFilterQuery()
        {
            ConfigKeys(x => x.SampleID);

            //ConfigSuppressedProperties(x => x.LeafCategories);

            //ConfigSuppressedResponseProperties(x => x.LeafCategories);
        }
    }
}
