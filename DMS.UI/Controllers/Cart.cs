﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS.Controllers
{
    public class Cart
    {
        public int pid { get; set; }
        public string pname { get; set; }
        public int qty { get; set; }
        public double price { get; set; }

        public double bill { get; set; }
    }
}