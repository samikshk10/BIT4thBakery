namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alter : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table regcustomer
                drop column cusername");
        }
        
        public override void Down()
        {
        }
    }
}
