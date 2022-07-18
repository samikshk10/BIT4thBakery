namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getorderuser : DbMigration
    {
        public override void Up()
        {
            Sql(@"create view getallorderusers as
select invoicetable.invoiceId, regcustomer.id, regcustomer.cfullname as 'user', 
 invoicetable.bill,invoicetable.payment, invoicetable.invoicedate
 from invoicetable
inner join regcustomer on regcustomer.id = invoicetable.id;");
        }
        
        public override void Down()
        {
        }
    }
}
