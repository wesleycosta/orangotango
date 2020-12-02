using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orangotango.Business.Models;

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

            builder.Property(p => p.Email)
                   .HasColumnName("Email")
                   .HasColumnType("VARCHAR(128)");

            builder.Property(p => p.Password)
                   .HasColumnName("Password")
                   .HasColumnType("VARCHAR(255)");

            builder.ToTable("Users2");
        }
    }
}
