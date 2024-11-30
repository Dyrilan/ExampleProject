using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.DB.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired();

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100)
                   //.HasAnnotation("Index", "IX_User_Email")
                   .IsUnicode(false);
        }
    }
}
