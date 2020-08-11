using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SFA.DAS.CourseDelivery.Domain.Entities;
using SFA.DAS.Courses.Data.UnitTests.DatabaseMock;

namespace SFA.DAS.CourseDelivery.Data.UnitTests.Repository.ProviderImportRepository
{
    public class WhenDeletingAllItems
    {
        private Mock<ICourseDeliveryDataContext> _courseDeliveryDataContext;
        private Data.Repository.ProviderImportRepository _providerImportRepository;
        private List<ProviderImport> _providerImports;

        [SetUp]
        public void Arrange()
        {
            _providerImports = new List<ProviderImport>
            {
                new ProviderImport
                {
                    Id = 1,
                    Name ="Test"
                },
                new ProviderImport
                {
                    Id = 1,
                    Name= "Test 2"
                }
            };

            _courseDeliveryDataContext = new Mock<ICourseDeliveryDataContext>();
            _courseDeliveryDataContext.Setup(x => x.ProviderImports).ReturnsDbSet(_providerImports);
            _providerImportRepository = new Data.Repository.ProviderImportRepository(_courseDeliveryDataContext.Object);
        }

        [Test]
        public void Then_The_ProviderImports_Are_Removed()
        {
            //Act
            _providerImportRepository.DeleteAll();
            
            //Assert
            _courseDeliveryDataContext.Verify(x=>x.ProviderImports.RemoveRange(_courseDeliveryDataContext.Object.ProviderImports), Times.Once);
            _courseDeliveryDataContext.Verify(x=>x.SaveChanges(), Times.Once);
        }
    }
}