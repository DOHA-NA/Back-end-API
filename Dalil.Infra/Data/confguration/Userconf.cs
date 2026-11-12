using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApiCe.Core.Entites;

namespace ApiCe.Infra.Data.configuration
{
    public class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Email)
                   .IsRequired();

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.Property(u => u.Role)
                   .IsRequired();

            builder.HasOne(u => u.Student)
                   .WithOne()
                   .HasForeignKey<User>(u => u.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}