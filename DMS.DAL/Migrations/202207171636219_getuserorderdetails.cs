namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class getuserorderdetails : DbMigration
    {
        public override void Up()
        {
//            Sql(@"drop view getallorderusers");

//            Sql(@"create view getallorderusers as
//select invoicetable.invoiceId, regcustomer.id, regcustomer.cfullname as 'user', 
// invoicetable.bill,invoicetable.payment, invoicetable.invoicedate,invoicetable.oid
// from invoicetable
//inner join regcustomer on regcustomer.id = invoicetable.id;");
//
       }
        
        public override void Down()
        {
        }
    }
}
