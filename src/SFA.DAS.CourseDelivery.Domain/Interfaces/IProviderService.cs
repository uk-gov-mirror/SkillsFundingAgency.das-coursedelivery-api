using System.Collections.Generic;
using System.Threading.Tasks;

namespace SFA.DAS.CourseDelivery.Domain.Interfaces
{
    public interface IProviderService
    {
        Task<IEnumerable<Entities.Provider>> GetProvidersByStandardId(int standardId);
        Task<Entities.ProviderStandard> GetProviderByUkprnAndStandard(int ukPrn, int standardId);
        Task<IEnumerable<Domain.Entities.NationalAchievementRateOverall>> GetOverallAchievementRates(string description);
        Task<IEnumerable<int>> GetStandardIdsByUkprn(int ukprn);
    }
}