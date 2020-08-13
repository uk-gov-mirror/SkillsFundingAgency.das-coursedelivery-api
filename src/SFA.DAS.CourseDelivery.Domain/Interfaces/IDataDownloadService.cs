using System.IO;
using System.Threading.Tasks;

namespace SFA.DAS.CourseDelivery.Domain.Interfaces
{
    public interface IDataDownloadService
    {
        Task<Stream> GetFileStream(string downloadPath);
    }
}