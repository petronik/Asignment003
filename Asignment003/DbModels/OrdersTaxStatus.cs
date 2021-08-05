﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Asignment003.DbModels
{
    public partial class OrdersTaxStatus
    {
        public OrdersTaxStatus()
        {
            Orders = new HashSet<Order>();
        }

        public sbyte Id { get; set; }
        public string TaxStatusName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
