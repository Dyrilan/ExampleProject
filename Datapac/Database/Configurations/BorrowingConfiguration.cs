using Example.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Example.DB.Configurations
{
    public class BorrowingConfiguration : IEntityTypeConfiguration<Borrowing>
    {
        public void Configure(EntityTypeBuilder<Borrowing> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.User)
                   .WithMany()
                   .HasForeignKey(b => b.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(b => b.Book)
                   .WithMany()
                   .HasForeignKey(b => b.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.BorrowingDate)
                .IsRequired();

            builder.Property(b => b.DueDate)
                .IsRequired();

            builder.Property(b => b.ReturnDate)
                .IsRequired(false);
        }
    }
}
