namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tabless : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table regcustomer(
                id int primary key identity,
                cfullname varchar(255) not null,
                caddress varchar(55) not null,
                cpno varchar(16) not null,
                cusername varchar(17) not null,
                cemail varchar(55) not null,
                cpassword varchar(55) not null
                );");
        }
        
        public override void Down()
        {
        }
    }
}
