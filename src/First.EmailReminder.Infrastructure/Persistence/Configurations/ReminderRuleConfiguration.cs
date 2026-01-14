using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Infrastructure.Persistence.Configurations
{
    public class ReminderRuleConfiguration : IEntityTypeConfiguration<ReminderRule>
    {
        public void Configure(EntityTypeBuilder<ReminderRule> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.SqlQuery)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Periodicity)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(a => a.PeriodicityValue)
                .IsRequired();

            builder.Property(a => a.SubjectTemplate)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.BodyTemplate)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(a => a.RecipientTemplate)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(a => a.NextRunAt)
                .IsRequired();

            builder.HasMany(a => a.Emails)
                .WithOne(c => c.ReminderRule)
                .HasForeignKey(a => a.ReminderRuleId);

            builder.HasOne(a => a.User)
                .WithMany(c => c.ReminderRules)
                .HasForeignKey(a => a.UserId);
        }
    }
}