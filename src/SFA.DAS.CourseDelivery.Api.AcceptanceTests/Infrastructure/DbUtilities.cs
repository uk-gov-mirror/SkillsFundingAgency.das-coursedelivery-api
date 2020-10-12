﻿using SFA.DAS.CourseDelivery.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.CourseDelivery.Api.AcceptanceTests.Infrastructure
{
    public class DbUtilities
    {
        //public static void LoadTestData(CourseDeliveryDataContext context)
        //{
        //    var testSectors = GetTestSectors().ToList();

        //    context.Pro
        //    context.Sectors.AddRange(testSectors);
        //    context.SectorSubjectAreaTier2.AddRange(GetSectorSubjectAreaTier2Items());
        //    context.Standards.AddRange(GetValidTestStandards());
        //    context.Standards.AddRange(GetInValidTestStandards());
        //    context.Frameworks.AddRange(GetFrameworks());
        //    context.SaveChanges();
        //}

        //public static void ClearTestData(CourseDeliveryDataContext context)
        //{
        //    context.st Standards.RemoveRange(context.Standards.ToList());
        //    context.Sectors.RemoveRange(context.Sectors.ToList());
        //    context.SectorSubjectAreaTier2.RemoveRange(context.SectorSubjectAreaTier2.ToList());
        //    context.Frameworks.RemoveRange(context.Frameworks.ToList());
        //    context.SaveChanges();
        //}

        //public static IEnumerable<SectorSubjectAreaTier2> GetSectorSubjectAreaTier2Items()
        //{
        //    return new List<SectorSubjectAreaTier2>
        //    {
        //        new SectorSubjectAreaTier2
        //        {
        //            EffectiveFrom = DateTime.Today,
        //            SectorSubjectAreaTier2Desc = "Test Sector",
        //            SectorSubjectAreaTier2 = 1m,
        //            Name = "Test Sector"
        //        },
        //        new SectorSubjectAreaTier2
        //        {
        //            EffectiveFrom = DateTime.Today,
        //            SectorSubjectAreaTier2Desc = "Test Sector 2",
        //            SectorSubjectAreaTier2 = 1.1m,
        //            Name = "Test Sector 2"
        //        }
        //    };
        //}

        //public static IEnumerable<Sector> GetTestSectors()
        //{
        //    return new List<Sector>
        //    {
        //        new Sector
        //        {
        //            Route = "Engineering and manufacturing",
        //            Id = Guid.Parse("54A073E7-F2BA-4C04-9868-1EC3AB3A89D4")
        //        },
        //        new Sector
        //        {
        //            Route = "Construction",
        //            Id = Guid.Parse("B30D7750-9ADF-41BA-94BD-E4584128EC76")
        //        },
        //        new Sector
        //        {
        //            Route = "Creative and design",
        //            Id = Guid.Parse("7ECB9D82-47A0-45EB-94FE-2F9E2161A55F")
        //        }
        //    };
        //}

        //public static IEnumerable<Standard> GetValidTestStandards()
        //{
        //    var sectors = GetTestSectors().ToList();
        //    var subjectSectorArea = GetSectorSubjectAreaTier2Items().ToList();
        //    return new List<Standard>
        //    {
        //        new Standard
        //        {
        //            Id = 1,
        //            Title = "Head Brewer",
        //            Keywords = "Head, Brewer, Beer",
        //            TypicalJobTitles = "Overseer of brewery operations",
        //            Level = 2,
        //            RouteId = sectors[0].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 1,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 2,
        //            Title = "Brewer",
        //            Keywords = "Brewer, Beer",
        //            TypicalJobTitles = "Brewery operations",
        //            Level = 1,
        //            RouteId = sectors[0].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 2,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 3,
        //            Title = "Senior / head of facilities management (degree)",
        //            Keywords = "Head",
        //            TypicalJobTitles = "Overseer of brewery operations",
        //            Level = 6,
        //            RouteId = sectors[1].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 3,
        //                SectorSubjectAreaTier2 = 1.1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 4,
        //            Title = "Dentist",
        //            Keywords = "Dentist|Dentistry",
        //            TypicalJobTitles = "Dentist",
        //            Level = 7,
        //            RouteId = sectors[1].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 4,
        //                SectorSubjectAreaTier2 = 1.1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 5,
        //            Title = "Photographic assistant SortOrder",
        //            Keywords = null,
        //            TypicalJobTitles = "Assistant Photographer|Photographic Technician",
        //            Level = 3,
        //            RouteId = sectors[2].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 5,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 6,
        //            Title = "Camera prep technician",
        //            Keywords = "SortOrder",
        //            TypicalJobTitles = "Camera prep technician|Camera equipment technician|",
        //            Level = 3,
        //            RouteId = sectors[2].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 6,
        //                SectorSubjectAreaTier2 = 1.1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 7,
        //            Title = "Junior animator SortOrder",
        //            Keywords = "SortOrder",
        //            TypicalJobTitles = "Junior animator|SortOrder",
        //            Level = 4,
        //            RouteId = sectors[2].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(-1),
        //                LastDateStarts = null,
        //                StandardId = 7,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        }
        //    };
        //}

        //public static IEnumerable<Standard> GetInValidTestStandards()
        //{
        //    var sectors = GetTestSectors().ToList();
        //    var subjectSectorArea = GetSectorSubjectAreaTier2Items().ToList();
        //    return new List<Standard>
        //    {
        //        new Standard
        //        {
        //            Id = 11,
        //            Title = "Head Brewer - invalid",
        //            Keywords = "Head, Brewer, Beer",
        //            TypicalJobTitles = "Overseer of brewery operations",
        //            Level = 2,
        //            RouteId = sectors[0].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(1),
        //                StandardId = 11,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        },
        //        new Standard
        //        {
        //            Id = 14,
        //            Title = "Dentist - invalid",
        //            Keywords = "Dentist|Dentistry",
        //            TypicalJobTitles = "Dentist",
        //            Level = 7,
        //            RouteId = sectors[1].Id,
        //            LarsStandard = new LarsStandard
        //            {
        //                EffectiveFrom = DateTime.UtcNow.AddDays(1),
        //                StandardId = 14,
        //                SectorSubjectAreaTier2 = 1m
        //            }
        //        }
        //    };
        //}

        //public static IEnumerable<Framework> GetFrameworks()
        //{
        //    return new List<Framework>
        //    {
        //        new Framework
        //        {
        //            Duration = 2,
        //            Id = "1",
        //            Level = 2,
        //            Title = "Test framework 1",
        //            EffectiveFrom = new DateTime(2020, 01, 01),
        //            EffectiveTo = new DateTime(2025, 01, 01),
        //            ExtendedTitle = "This is the test framework 1",
        //            FrameworkCode = 20,
        //            FrameworkName = "Framework test 1",
        //            MaxFunding = 10000,
        //            PathwayCode = 2,
        //            PathwayName = "Test pathway 1",
        //            ProgrammeType = 2,
        //            ProgType = 2,
        //            CurrentFundingCap = 20000,
        //            HasSubGroups = false,
        //            IsActiveFramework = true,
        //            TypicalLengthFrom = 2,
        //            TypicalLengthTo = 3,
        //            TypicalLengthUnit = "Years",
        //        },
        //        new Framework
        //        {
        //            Id = "2",
        //            Level = 3,
        //            Title = "Test framework 2",
        //            EffectiveFrom = new DateTime(2021, 01, 01),
        //            EffectiveTo = new DateTime(2022, 01, 01),
        //            ExtendedTitle = "This is the test framework 2",
        //            FrameworkCode = 3,
        //            FrameworkName = "Framework test 2",
        //            MaxFunding = 15000,
        //            PathwayCode = 1,
        //            PathwayName = "Test pathway 2",
        //            ProgrammeType = 4,
        //            ProgType = 4,
        //            CurrentFundingCap = 18000,
        //            HasSubGroups = true,
        //            IsActiveFramework = true,
        //            TypicalLengthFrom = 3,
        //            TypicalLengthTo = 4,
        //            TypicalLengthUnit = "Years",
        //        },
        //        new Framework
        //        {
        //            Id = "3",
        //            Level = 4,
        //            Title = "Test framework 3",
        //            EffectiveFrom = new DateTime(2015, 01, 01),
        //            EffectiveTo = new DateTime(2019, 01, 01),
        //            ExtendedTitle = "This is the test framework 3",
        //            FrameworkCode = 5,
        //            FrameworkName = "Framework test 3",
        //            MaxFunding = 8000,
        //            PathwayCode = 7,
        //            PathwayName = "Test pathway 3",
        //            ProgrammeType = 5,
        //            ProgType = 5,
        //            CurrentFundingCap = 2000,
        //            HasSubGroups = false,
        //            IsActiveFramework = false,
        //            TypicalLengthFrom = 1,
        //            TypicalLengthTo = 2,
        //            TypicalLengthUnit = "Years",
        //        },
        //    };
        //}

        //public static Framework GetFramework(string id)
        //{
        //    return GetFrameworks().FirstOrDefault(c => c.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase));
        //}
    }
}
