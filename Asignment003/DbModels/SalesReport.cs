﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Asignment003.DbModels
{
    public partial class SalesReport
    {
        public string GroupBy { get; set; }
        public string Display { get; set; }
        public string Title { get; set; }
        public string FilterRowSource { get; set; }
        public bool Default { get; set; }
    }
}
