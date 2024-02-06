﻿using Library.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.API.EntityMaps
{
    public class BookEntityMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.Name).HasMaxLength(50).IsRequired();
            builder.Property(_ => _.PublishDate).IsRequired();
            builder.Property(_ => _.Stock).IsRequired();

            builder.HasOne(_ => _.Genre)
               .WithMany(_ => _.Books)
               .HasForeignKey(_ => _.GenreId)
               .IsRequired();
            builder.HasOne(_ => _.Author)
            .WithMany(_ => _.Books)
            .HasForeignKey(_ => _.AuthorId)
            .IsRequired();
        }
    }
}
