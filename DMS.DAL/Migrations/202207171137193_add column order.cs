namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolumnorder : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table ordertable
                add odate date ");
        }
        
        public override void Down()
        {
        }
    }
}
