using System.Collections.Generic;
using System.Linq;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.CourseDelivery.Api.ApiResponses;
using SFA.DAS.CourseDelivery.Domain.Entities;
using SFA.DAS.CourseDelivery.Domain.Models;
using SFA.DAS.Testing.AutoFixture;

namespace SFA.DAS.CourseDelivery.Api.UnitTests.ApiResponses
{
    public class WhenMappingProviderEntityToGetCourseProviderResponse
    {
        [Test, RecursiveMoqAutoData]
        public void Then_Maps_Fields(ProviderLocation provider)
        {
            var actual = new GetProviderResponse().Map(provider);

            actual.Ukprn.Should().Be(provider.Ukprn);
            actual.Name.Should().Be(provider.Name);
        }

        [Test, RecursiveMoqAutoData]
        public void Then_The_Delivery_Modes_Are_Mapped_If_Available(ProviderLocation providerLocation)
        {
            var actual = new GetProviderResponse().Map(providerLocation);

            actual.DeliveryTypes.Count.Should().Be(providerLocation.DeliveryTypes.Count);
        }

        [Test, RecursiveMoqAutoData]
        public void Then_Only_All_Levels_And_All_Ages_Achievement_Rates_Are_Returned(ProviderLocation provider)
        {
            //Arrange
            provider.AchievementRates = new List<AchievementRate>
            {
                new AchievementRate
                {
                    Age = Age.AllAges,
                    ApprenticeshipLevel = ApprenticeshipLevel.AllLevels
                },
                new AchievementRate
                {
                    Age = Age.SixteenToEighteen,
                    ApprenticeshipLevel = ApprenticeshipLevel.AllLevels
                },
                new AchievementRate
                {
                    Age = Age.AllAges,
                    ApprenticeshipLevel = ApprenticeshipLevel.Three
                }
            };
            
            //Act
            var actual = new GetProviderResponse().Map(provider, (short)Age.AllAges, (short)ApprenticeshipLevel.AllLevels);
            
            //Assert
            actual.AchievementRates.Count.Should().Be(1);
        }
    }
}