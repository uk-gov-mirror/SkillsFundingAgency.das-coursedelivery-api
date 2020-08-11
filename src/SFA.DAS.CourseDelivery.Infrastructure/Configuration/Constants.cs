namespace SFA.DAS.CourseDelivery.Infrastructure.Configuration
{
    public static class Constants
    {
        public const string ScopeClaimType = "http://schemas.microsoft.com/identity/claims/scope";
        public const string ObjectIdClaimType = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public static string NationalAchievementRatesPageUrl => "https://www.gov.uk/government/statistics/national-achievement-rates-tables-{0}-to-{1}";
        public static string NationalAchievementRatesCsvFileName => "NART_vDM_Apprenticeships_Institution_SectorSubjectArea_Overall.csv";
    }
}