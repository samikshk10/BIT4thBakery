namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable1 : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table customer(
                    cid int primary key identity(100,1),
                    cfname varchar(50) not null,
                    cdob date not null,
                    caddress varchar(50),
                    cemail varchar(250),
                    cpassword varchar(250)
                
                    );");
        }
        
        public override void Down()
        {
        }
    }
}
