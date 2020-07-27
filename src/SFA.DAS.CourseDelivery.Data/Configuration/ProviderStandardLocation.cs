using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SFA.DAS.CourseDelivery.Data.Configuration
{
    public class ProviderStandardLocation : IEntityTypeConfiguration<Domain.Entities.ProviderStandardLocation>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ProviderStandardLocation> builder)
        {
            builder.ToTable("ProviderStandardLocation");
            builder.HasKey(x => new {x.Ukprn, x.StandardId, x.LocationId });
            
            builder.Property(c => c.StandardId).HasColumnName("StandardId").HasColumnType("int").IsRequired();
            builder.Property(c => c.Ukprn).HasColumnName("Ukprn").HasColumnType("int").IsRequired();
            builder.Property(c => c.LocationId).HasColumnName("LocationId").HasColumnType("int").IsRequired();
            builder.Property(c => c.DeliveryModes).HasColumnName("DeliveryModes").HasColumnType("varchar").HasMaxLength(256).IsRequired();
            builder.Property(c => c.Radius).HasColumnName("Radius").HasColumnType("decimal").IsRequired();

            builder.HasOne(c => c.Location)
                .WithOne(c=>c.ProviderStandardLocation)
                .HasPrincipalKey<Domain.Entities.StandardLocation>(c => c.LocationId)
                .HasForeignKey<Domain.Entities.ProviderStandardLocation>(c => c.LocationId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            
            builder.HasIndex(x => new { x.Ukprn , x.StandardId, x.LocationId }).IsUnique();
        }
    }
}