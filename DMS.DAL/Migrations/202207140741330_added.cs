namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table regcustomer(
                    id int primary key identity,
                    cfullname nvarchar(50) not null,
                    caddress nvarchar(50) not null,
                    cpno nvarchar(14) not null,
                    cemail nvarchar(50) not null,
                    cpassword nvarchar(50) not null
                    
                    );");
        }
        
        public override void Down()
        {
        }
    }
}
