namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createinvoice : DbMigration
    {
        public override void Up()
        {
            Sql(@"drop table invoicetable");

            Sql(@"create table invoicetable(
                invoiceid varchar(255) primary key,
                id int not null,
                bill decimal(18,2) not null,
                payment varchar(55) ,
                invoicedate date not null,
foreign key(id) references regcustomer(id)

)");

            Sql(@"alter table ordertable
                add invoiceid varchar(255) ");

            Sql(@"alter table ordertable
                add foreign key(invoiceid) references invoicetable(invoiceid)");
        }
        
        public override void Down()
        {
        }
    }
}
