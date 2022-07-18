namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoicetableadd : DbMigration
    {
        public override void Up()
        {
            Sql(@"create table invoicetable(
            invoiceid varchar(255) primary key,
           id int not null,
            oamount decimal(18,2),
            payment varchar(255),
                invoicedate date not null,
foreign key(id) references regcustomer(id),
foreign key(invoiceid) references ordertable(oid))
");
        }
        
        public override void Down()
        {
        }
    }
}
