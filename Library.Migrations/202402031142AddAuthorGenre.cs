using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031142)]
    public class _202402031142AddAuthorGenre : Migration
    {
        public override void Up()
        {
            Create.Table("Genres")
              .WithColumn("Id").AsInt32().Identity().PrimaryKey()
              .WithColumn("Title").AsString(50).NotNullable();
            Create.Table("Authors")
           .WithColumn("Id").AsInt32().Identity().PrimaryKey()
           .WithColumn("FullName").AsString(50).NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Authors");
            Delete.Table("Genres");

        }


    }
}
