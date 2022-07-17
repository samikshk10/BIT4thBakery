using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.DatabaseContext
{
    class Cart
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int qty { get; set; }
        public float price { get; set; }

        public float bill { get; set; }
    }
}
