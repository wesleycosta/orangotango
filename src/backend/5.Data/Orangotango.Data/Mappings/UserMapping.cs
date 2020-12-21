using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orangotango.Business.Models;
using Orangotango.Business.Models.DomainObjects;

namespace Orangotango.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FristName)
                   .HasColumnName("FristName")
                   .HasColumnType("VARCHAR(128)");

            builder.Property(p => p.LastName)
                   .HasColumnName("LastName")
                   .HasColumnType("VARCHAR(128)");

            builder.Property(p => p.NickName)
                   .HasColumnName("NickName")
                   .HasColumnType("VARCHAR(128)");

            builder.OwnsOne(p => p.Email, q =>
            {
                q.Property(p => p.EmailAddress)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"VARCHAR({Email.MAX_LENGTH})");
            });

            builder.Property(p => p.Password)
                   .HasColumnName("Password")
                   .HasColumnType("VARCHAR(255)");

            builder.ToTable("Users");
        }
    }
}
