using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityMaps
{
    public class UserEntityMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_=>_.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(_ => _.Email).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(_ => _.CreateAt).HasColumnType("datetime").HasMaxLength(50).IsRequired();


        }
    }
}
