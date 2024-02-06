using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031133)]
    public class _202402031133AddBookTBL : Migration
    {
        public override void Up()
        {
            Create.Table("Books")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("PublishDate").AsDate().NotNullable()
                .WithColumn("Stock").AsInt32().NotNullable()
                .WithColumn("Author").AsString(50).NotNullable()
                .WithColumn("Genre").AsString(50).NotNullable();


        }
        public override void Down()
        {
            Delete.Table("Books");
        }


    }
}
