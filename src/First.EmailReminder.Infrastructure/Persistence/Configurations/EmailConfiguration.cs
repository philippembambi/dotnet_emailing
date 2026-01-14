using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Infrastructure.Persistence.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Subject)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Body)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(a => a.Recipient)
                .HasMaxLength(255)
                .IsRequired();
            
            builder.Property(a => a.RecipientType)
                .HasConversion<string>()
                .IsRequired();

            builder.Property(a => a.Status)
                .HasConversion<string>()
                .IsRequired();
            
            builder.Property(a => a.AttemptCount)
                .IsRequired();
            
            builder.Property(a => a.SentAt)
                .IsRequired(false);

            builder.HasOne(a => a.ReminderRule)
                .WithMany(c => c.Emails)
                .HasForeignKey(a => a.ReminderRuleId);
        }
    }
}