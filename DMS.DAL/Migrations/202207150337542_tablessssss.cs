namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablessssss : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table usr05users
        drop column isadmin ");

            Sql(@"alter table usr05users
        add  isadmin bit");
        }
        
        public override void Down()
        {
        }
    }
}
