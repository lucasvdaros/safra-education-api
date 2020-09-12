using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafraEducacional.Domain.Entity;

namespace SafraEducacional.Infra.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(ar => ar.Id);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("email"); ;

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnName("name");

            builder.Property(c => c.BirthOn)
                .HasColumnName("birth_on");

            builder.Property(c => c.Ddd)
                .IsRequired()
                .HasColumnName("ddd");

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasColumnName("phone");

            builder.Property(c => c.PasswordDigest)
                .HasColumnName("password_digest");

            builder.Property(c => c.CreatedAt)
                .HasColumnName("created_at");

            builder.Property(c => c.UpdatedAt)
                .HasColumnName("updated_at");
        }
    }
}
