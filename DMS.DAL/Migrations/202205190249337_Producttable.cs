namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Producttable : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table producttable(
                    pid int primary key identity,
                    pname nvarchar(50) not null,
                    pcategory nvarchar(50) not null,
                    pprice decimal(18,2) not null,
                    pimage  varchar(300) not null
                    );");
        }
        
        public override void Down()
        {
        }
    }
}
