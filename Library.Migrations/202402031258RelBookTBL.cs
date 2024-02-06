using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031258)]
    public class _202402031258RelBookTBL : Migration
    {
        public override void Up()
        {
            Alter.Table("Books")
           .AddColumn("AuthorId").AsInt32().NotNullable()
             .ForeignKey("FK_Books_Authors", "Authors", "Id")
           .AddColumn("GenreId").AsInt32().NotNullable()
            .ForeignKey("FK_Books_Genres", "Genres", "Id");

        }
        public override void Down()
        {
            Delete.ForeignKey("FK_Books_Genres").OnTable("Books");
            Delete.Column("GenreId").FromTable("Books");

            Delete.ForeignKey("FK_Books_Authors").OnTable("Books");
            Delete.Column("AuthorId").FromTable("Books");
        }


    }
}
