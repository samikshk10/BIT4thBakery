using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DMS.DAL.DatabaseContext;

namespace DMS.Controllers
{
    public class item
    {
        private producttable producttable = new producttable();
       


        public producttable Producttable
        {
            get { return producttable; }
            set { producttable = value; }
        }
        private int quantity;

        
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public item() { }
        public item(producttable producttable, int quantity)
        {
            this.producttable = producttable;
            this.quantity = quantity;
        }

    }
}