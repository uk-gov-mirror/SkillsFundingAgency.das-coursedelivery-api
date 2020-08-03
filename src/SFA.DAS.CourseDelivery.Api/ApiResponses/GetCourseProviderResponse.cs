using Newtonsoft.Json;
using SFA.DAS.CourseDelivery.Domain.Entities;

namespace SFA.DAS.CourseDelivery.Api.ApiResponses
{
    public class GetCourseProviderResponse
    {
        public int Ukprn { get ; set ; }

        public string Name { get ; set ; }

        public static implicit operator GetCourseProviderResponse(Provider provider)
        {
            return new GetCourseProviderResponse
            {
                Ukprn = provider.Ukprn,
                Name = provider.Name

            };
        }
    }
}