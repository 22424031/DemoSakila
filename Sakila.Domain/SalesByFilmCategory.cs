﻿using System;
using System.Collections.Generic;

namespace Sakila.Domain
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; } = null!;
        public decimal? TotalSales { get; set; }
    }
}
