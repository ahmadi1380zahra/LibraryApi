using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031123)]
    public class _202402031123AddUserTBl : Migration
    {
        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable()
                .WithColumn("CreateAt").AsDateTime().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Users");
        }

     
    }
}
