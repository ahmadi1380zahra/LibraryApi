using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityMaps
{
    public class UserRentBookEntityMap : IEntityTypeConfiguration<UserRentBook>
    {
        public void Configure(EntityTypeBuilder<UserRentBook> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.IsBack).IsRequired();

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.UserRentBooks)
                .HasForeignKey(_ => _.UserId)
                .IsRequired();
            builder.HasOne(_ => _.Book)
               .WithMany(_ => _.UserRentBooks)
               .HasForeignKey(_ => _.BookId)
               .IsRequired();
        }
    }
}
