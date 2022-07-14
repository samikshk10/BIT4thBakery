namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedproducttable : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table producttable
                    add pmfddate date");

            Sql(@"alter table producttable
                        add pexpdate date");
        }
        
        public override void Down()
        {
        }
    }
}
