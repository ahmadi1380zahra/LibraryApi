using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031248)]
    public class _202402031248AlterBookTBL : Migration
    {
        public override void Up()
        {
            Delete.Column("Author").FromTable("Books");
            Delete.Column("Genre").FromTable("Books");
        }
        public override void Down()
        {
            Alter.Table("Books")
         .AddColumn("Genre").AsString(50).NotNullable().WithDefaultValue("Genre")
         .AddColumn("Author").AsString(50).NotNullable().WithDefaultValue("Author");
        }


    }
}
