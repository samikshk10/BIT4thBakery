namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnproduct : DbMigration
    {
        public override void Up()
        {
            Sql(@"alter table ordertable
                    add pid int not null
                    ");

            Sql(@"alter table ordertable
                    add foreign key(pid) references producttable(pid)  "); 
        }
        
        public override void Down()
        {
        }
    }
}
