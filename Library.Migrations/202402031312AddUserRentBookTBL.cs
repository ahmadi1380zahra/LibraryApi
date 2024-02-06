using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Migrations
{
    [Migration(202402031312)]
    public class _202402031312AddUserRentBookTBL : Migration
    {
        public override void Up()
        {
            Create.Table("UserRentBook")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("IsBack").AsBoolean().NotNullable()
                .WithColumn("UserId").AsInt32().NotNullable()
                 .ForeignKey("FK_UserRentBook_Users", "Users", "Id")
                .WithColumn("BookId").AsInt32().NotNullable()
                 .ForeignKey("FK_UserRentBook_Books", "Books", "Id");
        }
        public override void Down()
        {
            Delete.Table("UserRentBook");
        }

      
    }
}
