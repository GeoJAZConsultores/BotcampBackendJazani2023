using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Generals.Configurations
{
    public class MineralTypeConfiguration : IEntityTypeConfiguration<MineralType>
    {
        public void Configure(EntityTypeBuilder<MineralType> builder)
        {
            var toDateTime = new ValueConverter<DateTime, DateTimeOffset>(
                   dateTime  => DateTimeOffset.UtcNow,
                   dateTimeOffset => dateTimeOffset.DateTime
                );

            builder.ToTable("mineraltype", "ge");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasColumnName("name");
            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.Slug).HasColumnName("slug");
            builder.Property(t => t.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(toDateTime);
            builder.Property(t => t.State).HasColumnName("state");
        }
    }
}

