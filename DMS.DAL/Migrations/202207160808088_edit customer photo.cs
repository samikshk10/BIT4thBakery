namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcustomerphoto : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table regcustomer
                  add cphoto varchar(255)");
        }
        
        public override void Down()
        {
        }
    }
}
