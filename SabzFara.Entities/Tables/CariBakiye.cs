﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzFara.Entities.Tables
{
   public class CariBakiye
    {
        public string CariKodu { get; set; }
        public decimal Alacak { get; set; }
        public decimal Borc { get; set; }
        public decimal Bakiye { get; set; }
    }
}
