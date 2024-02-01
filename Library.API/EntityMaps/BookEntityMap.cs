using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityMaps
{
    public class BookEntityMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
            builder.Property(_ => _.PublishDate).HasColumnType("datetime").HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Stock);
        }
    }


}
