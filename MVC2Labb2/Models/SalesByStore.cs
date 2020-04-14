﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2Labb2.Models
{
    public partial class SalesByStore
    {
        [Column("store_id")]
        public int StoreId { get; set; }
        [Required]
        [Column("store")]
        [StringLength(101)]
        public string Store { get; set; }
        [Required]
        [Column("manager")]
        [StringLength(91)]
        public string Manager { get; set; }
        [Column("total_sales", TypeName = "decimal(38, 2)")]
        public decimal? TotalSales { get; set; }
    }
}
