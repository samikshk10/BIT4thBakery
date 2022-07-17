namespace DMS.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class view : DbMigration
    {
        public override void Up()
        {
            Sql(@"create view getallorders as
select regcustomer.cfullname,regcustomer.id as 'user', producttable.pname as 'pro_name', 
regcustomer.cpno, regcustomer.caddress, ordertable.oprice , ordertable.oqty,  ordertable.oamount, ordertable.odate,regcustomer.cemail from regcustomer
inner join ordertable on ordertable.id = regcustomer.id
inner join producttable on producttable.pid = ordertable.pid;");

        }
        
        public override void Down()
        {
        }
    }
}
