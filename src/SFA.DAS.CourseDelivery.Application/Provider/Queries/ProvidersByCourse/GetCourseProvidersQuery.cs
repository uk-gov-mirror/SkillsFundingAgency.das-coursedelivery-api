using MediatR;

namespace SFA.DAS.CourseDelivery.Application.Provider.Queries.ProvidersByCourse
{
    public class GetCourseProvidersQuery : IRequest<GetCourseProvidersResponse>
    {
        public int StandardId { get ; set ; }
        public double? Lat { get ; set ; }
        public double? Lon { get ; set ; }
        public short SortOrder { get ; set ; }
    }
}