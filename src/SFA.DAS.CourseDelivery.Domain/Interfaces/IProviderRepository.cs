using System.Collections.Generic;
using System.Threading.Tasks;
using SFA.DAS.CourseDelivery.Domain.Entities;

namespace SFA.DAS.CourseDelivery.Domain.Interfaces
{
    public interface IProviderRepository
    {
        Task InsertMany(IEnumerable<Provider> providers);
        void DeleteAll();
        Task<IEnumerable<Provider>> GetByStandardId(int standardId);
        Task<Provider> GetByUkprn(int ukPrn);
    }
}