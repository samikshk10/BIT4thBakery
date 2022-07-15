namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablessss : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table usr05users
                    add isadmin varchar(50)
                ");
        }
        
        public override void Down()
        {
        }
    }
}
