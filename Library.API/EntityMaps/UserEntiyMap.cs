using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.EntityMaps
{
    public class UserEntiyMap : IEntityTypeConfiguration<User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.Email).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.CreateAt).IsRequired();
        }
    }
}
