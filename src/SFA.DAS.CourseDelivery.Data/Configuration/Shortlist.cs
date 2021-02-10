﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SFA.DAS.CourseDelivery.Data.Configuration
{
    public class Shortlist : IEntityTypeConfiguration<Domain.Entities.Shortlist>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Shortlist> builder)
        {
            builder.ToTable("Shortlist");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x=> new {x.ShortlistUserId, x.CourseId, x.ProviderUkprn, x.Lat,x.Long}).IsUnique();

            builder.Property(x => x.Id).HasColumnName("Id").HasColumnType("UniqueIdentifier").IsRequired();
            builder.Property(x => x.ShortlistUserId).HasColumnName("ShortlistUserId").HasColumnType("UniqueIdentifier").IsRequired();
            builder.Property(x => x.ProviderUkprn).HasColumnName("ProviderUkprn").HasColumnType("int").IsRequired();
            builder.Property(x => x.CourseId).HasColumnName("CourseId").HasColumnType("int").IsRequired();
            builder.Property(x => x.CourseLevel).HasColumnName("CourseLevel").HasColumnType("smallint").IsRequired();
            builder.Property(x => x.CourseSector).HasColumnName("CourseSector").HasColumnType("varchar").HasMaxLength(1000).IsRequired();
            builder.Property(x => x.LocationDescription).HasColumnName("LocationDescription").HasColumnType("varchar").HasMaxLength(1000);
            builder.Property(x => x.Lat).HasColumnName("Lat").HasColumnType("float");
            builder.Property(x => x.Long).HasColumnName("Long").HasColumnType("float");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").HasColumnType("datetime").IsRequired();

            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}