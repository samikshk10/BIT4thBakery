namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_table : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table test(
                    id int primary key identity,
                    name nvarchar(50) not null,
                    address nvarchar(50) not null,
                    contact nvarchar(14) not null

                    
                    );");
        }
        
        public override void Down()
        {
        }
    }
}
