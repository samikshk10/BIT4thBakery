namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedordertable : DbMigration
    {
        public override void Up()
        {
                Sql(@"create table ordertable(
                    oid varchar(255) primary key,
                    id int not null,
                    foreign key(id) references regcustomer(id),
                    oqty int not null,
                    oprice decimal(18,2) not null,
                    oamount decimal(18,2) not null
);");
        }
        
        public override void Down()
        {
        }
    }
}
