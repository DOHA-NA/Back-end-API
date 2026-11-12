using ApiCe.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using dalil.Core;

namespace ApiCe.Infra.Data.ApiCe.Studentconf
{
    public class Studentconf : IEntityTypeConfiguration<Student>
    {
       public void Configure(EntityTypeBuilder<Student> builder)
{
    builder.Property(s => s.FullName)
           .IsRequired();

    builder.Property(s => s.Email)
           .IsRequired();

    builder.HasIndex(s => s.Email)
           .IsUnique();
}

    }
}