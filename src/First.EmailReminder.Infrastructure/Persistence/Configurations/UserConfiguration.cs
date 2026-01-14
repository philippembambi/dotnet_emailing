using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using First.EmailReminder.Domain.Entities;

namespace First.EmailReminder.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(a => a.Name)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(a => a.PasswordHash)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            builder.Property(a => a.Role)
                .HasConversion<string>()
                .IsRequired();

            builder.HasMany(a => a.ReminderRules)
                .WithOne(c => c.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}